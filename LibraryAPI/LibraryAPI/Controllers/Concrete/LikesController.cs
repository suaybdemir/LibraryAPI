using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models.Concrete;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers.Concrete
{
    [Authorize(Policy = "AllUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LikesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
          if (_context.Like == null)
          {
              return NotFound();
          }
            return await _context.Like.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<Like>> GetLike(string userId, int representativeBookId)
        {
          if (_context.Like == null)
          {
              return NotFound();
          }
            var like = await _context.Like
               .FirstOrDefaultAsync(dl => dl.UserId == userId && dl.RepresentativeBookId == representativeBookId);


            if (like == null)
            {
                return NotFound();
            }

            return like;
        }


        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Like>> PostLike(string userId, int representativeBookId)
        {
            if (_context.Like == null)
            {
                return Problem("Entity set 'ApplicationContext.Like' is null.");
            }

            var user = await _context.Members!.FindAsync(userId);

            if (user == null)
            {
                return Problem("User cannot be null");
            }

            var existingLike = await _context.Like
                .FirstOrDefaultAsync(l => l.UserId == userId && l.RepresentativeBookId == representativeBookId);

            if (existingLike != null)
            {
                return Problem("Already Liked");
            }

            var representativeBook = await _context.RepresentativeBooks!.FindAsync(representativeBookId);

            if (representativeBook == null)
            {
                return NotFound();
            }

            var newLike = new Like
            {
                UserId = userId,
                RepresentativeBookId = representativeBookId
            };

            _context.Like.Add(newLike);

            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetLike), new { id = newLike.UserId }, newLike);
        }


        // DELETE: api/Likes/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteLike(string userId,int representativeBookId)
        {
            if (_context.Like == null)
            {
                return Problem("Entity set 'ApplicationContext.Like' is null.");
            }

            var user = await _context.Members!.FindAsync(userId);

            if (user == null)
            {
                return Problem("User cannot be null");
            }

            var existingLike = await _context.Like
                .FirstOrDefaultAsync(l => l.UserId == userId && l.RepresentativeBookId == representativeBookId);

            if (existingLike == null)
            {
                return NotFound();
            }

            var representativeBook = await _context.RepresentativeBooks!.FindAsync(representativeBookId);

            if (representativeBook == null)
            {
                return NotFound();
            }

            _context.Like.Remove(existingLike);


            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeExists(string id)
        {
            return (_context.Like?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
