using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers.Concrete
{
    [Authorize(Policy = "AllUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeBooksRatingController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RepresentativeBooksRatingController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RepresentativeBooksRating
        [HttpGet("GetRepresentativeBookRatings")]
        public async Task<ActionResult<IEnumerable<RepresentativeBookRating>>> GetRepresentativeBookRatings()
        {
          if (_context.RepresentativeBookRating == null)
          {
              return NotFound();
          }
            return await _context.RepresentativeBookRating.ToListAsync();
        }

        // GET: api/RepresentativeBooksRating/5
        [HttpGet("GetRepresentativeBookRatingById")]
        public async Task<ActionResult<RepresentativeBookRating>> GetRepresentativeBookRatingById(int id)
        {
          if (_context.RepresentativeBookRating == null)
          {
              return NotFound();
          }
            var representativeBookRating = await _context.RepresentativeBookRating.FindAsync(id);

            if (representativeBookRating == null)
            {
                return NotFound();
            }

            return representativeBookRating;
        }



        [HttpPut("UpdateRepresentativeBookRating")]
        public async Task<IActionResult> UpdateRepresentativeBookRating(double Rating, int RepresentativeBookId, string UserId)
        {
            // Validate rating range
            if (Rating < 0 || Rating > 5)
            {
                return Problem("Rating must be in the range of 0 to 5.");
            }

            // Check if the representative book rating entity set is null
            if (_context.RepresentativeBookRating == null)
            {
                return Problem("Entity set 'ApplicationContext.RepresentativeBookRating' is null.");
            }

            // Find the representative book
            var representativeBook = await _context.RepresentativeBooks
                .FindAsync(RepresentativeBookId);

            if (representativeBook == null)
            {
                return NotFound("RepresentativeBook not found.");
            }

            // Find the existing rating
            var existingRating = await _context.RepresentativeBookRating
                .FirstOrDefaultAsync(rbr => rbr.RepresentativeBookId == RepresentativeBookId && rbr.UserId == UserId);

            if (existingRating == null)
            {
                return NotFound("Rating not found for this user.");
            }

            // Update the existing rating
            existingRating.Rating = (float)Rating;

            // Save changes to update the rating
            await _context.SaveChangesAsync();

            // Recalculate average rating
            var allRatings = await _context.RepresentativeBookRating
                .Where(rbr => rbr.RepresentativeBookId == RepresentativeBookId)
                .ToListAsync();

            float totalRating = allRatings.Sum(rbr => rbr.Rating);
            float averageRating = allRatings.Count > 0 ? totalRating / allRatings.Count : 0;

            representativeBook.Rating = averageRating;  // Ensure this is a float or double
            _context.RepresentativeBooks.Update(representativeBook);

            // Save changes again to update the book's rating
            await _context.SaveChangesAsync();

            return NoContent();  // Indicate successful update
        }



        [HttpPost("PostRepresentativeBookRating")]
        public async Task<ActionResult<RepresentativeBook>> PostRepresentativeBookRating(double Rating, int RepresentativeBookId, string UserId)
        {
            // Check if rating is within valid range
            if (Rating < 0 || Rating > 5)
            {
                return Problem("Rating must be in the range of 0 to 5.");
            }

            // Check if the representative book rating entity set is null
            if (_context.RepresentativeBookRating == null)
            {
                return Problem("Entity set 'ApplicationContext.RepresentativeBookRating' is null.");
            }

            // Find the representative book
            var representativeBook = await _context.RepresentativeBooks
                .FindAsync(RepresentativeBookId);

            if (representativeBook == null)
            {
                return NotFound("RepresentativeBook not found.");
            }

            // Check if the user has already rated this book
            var existingRating = await _context.RepresentativeBookRating
                .FirstOrDefaultAsync(rbr => rbr.RepresentativeBookId == RepresentativeBookId && rbr.UserId == UserId);

            if (existingRating != null)
            {
                // Update existing rating
                existingRating.Rating = (float)Rating;
            }
            else
            {
                // Add new rating
                var newRating = new RepresentativeBookRating
                {
                    RepresentativeBookId = RepresentativeBookId,
                    UserId = UserId,
                    Rating = (float)Rating
                };

                _context.RepresentativeBookRating.Add(newRating);
            }

            // Save changes to ensure new ratings are in the database
            await _context.SaveChangesAsync();

            // Recalculate average rating
            var allRatings = await _context.RepresentativeBookRating
                .Where(rbr => rbr.RepresentativeBookId == RepresentativeBookId)
                .ToListAsync();

            float totalRating = allRatings.Sum(rbr => rbr.Rating);
            float averageRating = allRatings.Count > 0 ? totalRating / allRatings.Count : 0;

            representativeBook.Rating = averageRating;  // Ensure this is a float or double
            _context.RepresentativeBooks.Update(representativeBook);

            // Save changes again to update the book's rating
            await _context.SaveChangesAsync();

            return Ok(representativeBook);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteRepresentativeBookRating")]
        public async Task<IActionResult> DeleteRepresentativeBookRating(int RepresentativeBookId, string UserId)
        {
            // Check if the representative book rating entity set is null
            if (_context.RepresentativeBookRating == null)
            {
                return Problem("Entity set 'ApplicationContext.RepresentativeBookRating' is null.");
            }

            // Find the representative book
            var representativeBook = await _context.RepresentativeBooks
                .FindAsync(RepresentativeBookId);

            if (representativeBook == null)
            {
                return NotFound("RepresentativeBook not found.");
            }

            // Find the existing rating
            var existingRating = await _context.RepresentativeBookRating
                .FirstOrDefaultAsync(rbr => rbr.RepresentativeBookId == RepresentativeBookId && rbr.UserId == UserId);

            if (existingRating == null)
            {
                return NotFound("Rating not found for this user.");
            }

            // Remove the rating
            _context.RepresentativeBookRating.Remove(existingRating);

            // Save changes to commit the deletion
            await _context.SaveChangesAsync();

            // Recalculate average rating
            var allRatings = await _context.RepresentativeBookRating
                .Where(rbr => rbr.RepresentativeBookId == RepresentativeBookId)
                .ToListAsync();

            float totalRating = allRatings.Sum(rbr => rbr.Rating);
            float averageRating = allRatings.Count > 0 ? totalRating / allRatings.Count : 0;

            representativeBook.Rating = averageRating;  // Ensure this is a float or double
            _context.RepresentativeBooks.Update(representativeBook);

            // Save changes again to update the book's rating
            await _context.SaveChangesAsync();

            return NoContent();  // Indicate successful deletion
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteAllRatingsForRepresentativeBook")]
        public async Task<IActionResult> DeleteAllRatingsForRepresentativeBook(int RepresentativeBookId)
        {
            // Check if the representative book rating entity set is null
            if (_context.RepresentativeBookRating == null)
            {
                return Problem("Entity set 'ApplicationContext.RepresentativeBookRating' is null.");
            }

            // Find the representative book
            var representativeBook = await _context.RepresentativeBooks
                .FindAsync(RepresentativeBookId);

            if (representativeBook == null)
            {
                return NotFound("RepresentativeBook not found.");
            }

            // Find all ratings for the representative book
            var ratingsToDelete = await _context.RepresentativeBookRating
                .Where(rbr => rbr.RepresentativeBookId == RepresentativeBookId)
                .ToListAsync();

            if (ratingsToDelete.Count == 0)
            {
                return NotFound("No ratings found for this RepresentativeBook.");
            }

            // Remove the ratings
            _context.RepresentativeBookRating.RemoveRange(ratingsToDelete);

            // Optionally, reset the book's rating to zero or another default value
            representativeBook.Rating = 0;  // or another appropriate default value
            _context.RepresentativeBooks.Update(representativeBook);

            // Save changes to commit the deletion and update
            await _context.SaveChangesAsync();

            return NoContent();  // Indicate successful deletion
        }



        private bool RepresentativeBookRatingExists(int id)
        {
            return (_context.RepresentativeBookRating?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
