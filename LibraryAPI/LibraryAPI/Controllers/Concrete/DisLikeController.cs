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
    public class DisLikeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DisLikeController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DisLike
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisLike>>> GetDisLikes()
        {
          if (_context.DisLike == null)
          {
              return NotFound();
          }
            return await _context.DisLike.ToListAsync();
        }

        // GET: api/DisLike/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<DisLike>> GetDisLike(string userId,int representativeBookId)
        {
          if (_context.DisLike == null)
          {
              return NotFound();
          }
            var disLike = await _context.DisLike
                .FirstOrDefaultAsync(dl=>dl.UserId == userId && dl.RepresentativeBookId == representativeBookId);

            if (disLike == null)
            {
                return NotFound();
            }

            return disLike;
        }

        // PUT: api/DisLike/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutDisLike(string userId, DisLike disLike)
        {
            if (userId != disLike.UserId)
            {
                return BadRequest();
            }

            _context.Entry(disLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisLikeExists(userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DisLike
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisLike>> PostDisLike(string userId, int representativeBookId)
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

            var existingDisLike = await _context.DisLike!
                .FirstOrDefaultAsync(l => l.UserId == userId && l.RepresentativeBookId == representativeBookId);

            if (existingDisLike != null)
            {
                return Problem("Already Liked");
            }

            var representativeBook = await _context.RepresentativeBooks!.FindAsync(representativeBookId);

            if (representativeBook == null)
            {
                return NotFound();
            }

            var newDisLike = new DisLike
            {
                UserId = userId,
                RepresentativeBookId = representativeBookId
            };

            _context.DisLike!.Add(newDisLike);

            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetDisLike), new { id = newDisLike.UserId }, newDisLike);
        }

        // DELETE: api/DisLike/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisLike(string userId, int representativeBookId)
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

            var existingDisLike = await _context.DisLike!
                .FirstOrDefaultAsync(l => l.UserId == userId && l.RepresentativeBookId == representativeBookId);

            if (existingDisLike == null)
            {
                return NotFound();
            }

            var representativeBook = await _context.RepresentativeBooks!.FindAsync(representativeBookId);

            if (representativeBook == null)
            {
                return NotFound();
            }

            _context.DisLike!.Remove(existingDisLike);


            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisLikeExists(string id)
        {
            return (_context.DisLike?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
