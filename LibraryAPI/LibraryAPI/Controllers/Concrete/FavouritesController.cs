using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using LibraryAPI.Models.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavouritesController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Favourites/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavouriteBooksByUserId(string userId)
        {
            // Fetch the favourite entries for the specified userId
            var favourites = await _context.Favourites
                .Where(f => f.UserId == userId)
                .Include(f => f.RepresentativeBooks) // Include the related RepresentativeBooks
                .ToListAsync();

            if (!favourites.Any())
            {
                return NotFound(); // Return 404 Not Found if no favourite entry is found for the userId
            }

            // Extract the list of RepresentativeBooks from the favourite entries
            var representativeBooks = favourites
                .Select(f => f.RepresentativeBooks) // Select the related RepresentativeBooks
                .ToList();

            return Ok(representativeBooks); // Return the list of RepresentativeBooks with 200 OK status
        }




        // GET: api/Favourites/{userId}/{representativeBookId}
        [HttpGet("{userId}/{representativeBookId}")]
        public async Task<ActionResult<Favourite>> GetFavourite(string userId, int representativeBookId)
        {
            if (_context.Favourites == null)
            {
                return NotFound(); // Return 404 if the Favourites DbSet is null
            }

            // Find the favourite entry by composite key
            var favourite = await _context.Favourites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.RepresentativeBookId == representativeBookId);

            if (favourite == null)
            {
                return NotFound(); // Return 404 if the favourite entry is not found
            }

            return Ok(favourite); // Return the favourite entry with 200 OK status
        }






        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(string userId,int representativeBookId)
        {

            Favourite favourite;

            RepresentativeBook representativeBook = await _context.RepresentativeBooks!
                .FindAsync(representativeBookId);


          if (representativeBook == null)
          {
              return Problem("Entity set 'ApplicationContext.Favourites'  is null.");
          }

            favourite = new Favourite();


            favourite.UserId = userId;
            favourite.RepresentativeBookId = representativeBookId;

            await _context.Favourites!.AddAsync(favourite);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavouriteExists(favourite.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Favourite added succesfully!");
        }

        // DELETE: api/Favourites/{userId}/{representativeBookId}
        [HttpDelete("{userId}/{representativeBookId}")]
        public async Task<IActionResult> DeleteFavourite(string userId, int representativeBookId)
        {
            if (_context.Favourites == null)
            {
                return NotFound(); // Return 404 if the Favourites DbSet is null
            }

            // Find the favourite entry by composite key
            var favourite = await _context.Favourites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.RepresentativeBookId == representativeBookId);

            if (favourite == null)
            {
                return NotFound(); // Return 404 if the favourite entry is not found
            }

            _context.Favourites.Remove(favourite); // Remove the found favourite entry
            await _context.SaveChangesAsync(); // Save changes to the database

            return NoContent(); // Return 204 No Content on successful deletion
        }


        private bool FavouriteExists(string id)
        {
            return (_context.Favourites?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
