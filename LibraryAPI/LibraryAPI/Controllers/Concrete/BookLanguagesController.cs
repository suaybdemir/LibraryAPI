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
    [Authorize(Roles = "Admin,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookLanguagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BookLanguagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BookLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookLanguage>>> GetBookLanguages()
        {
          if (_context.BookLanguage == null)
          {
              return NotFound();
          }
            return await _context.BookLanguage.ToListAsync();
        }

        // GET: api/BookLanguages/5
        [HttpGet("{code}")]
        public async Task<ActionResult<BookLanguage>> GetBookLanguage(string code,int representativeBookId)
        {
          if (_context.BookLanguage == null)
          {
              return NotFound();
          }
            var bookLanguage = await _context.BookLanguage
                .FirstOrDefaultAsync(bl=>bl.LanguageCode == code && bl.RepresentativeBookId == representativeBookId);

            if (bookLanguage == null)
            {
                return NotFound();
            }

            return bookLanguage;
        }

        // PUT: api/BookLanguages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public async Task<IActionResult> PutBookLanguage(string code, BookLanguage bookLanguage)
        {
            if (code != bookLanguage.LanguageCode)
            {
                return BadRequest();
            }

            _context.Entry(bookLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookLanguageExists(code))
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

        // POST: api/BookLanguages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookLanguage>> PostBookLanguage(BookLanguage bookLanguage)
        {
          if (_context.BookLanguage == null)
          {
              return Problem("Entity set 'ApplicationContext.BookLanguage'  is null.");
          }
            _context.BookLanguage.Add(bookLanguage);

            await _context.SaveChangesAsync();
          
            return CreatedAtAction("GetBookLanguage", new { id = bookLanguage.LanguageCode }, bookLanguage);
        }

        // DELETE: api/BookLanguages/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteBookLanguage(string code,int representativeBookId)
        {
            if (_context.BookLanguage == null)
            {
                return NotFound();
            }
            var bookLanguage = await _context.BookLanguage
                .FirstOrDefaultAsync(bl => bl.LanguageCode == code && bl.RepresentativeBookId == representativeBookId);

            if (bookLanguage == null)
            {
                return NotFound();
            }

            _context.BookLanguage.Remove(bookLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookLanguageExists(string id)
        {
            return (_context.BookLanguage?.Any(e => e.LanguageCode == id)).GetValueOrDefault();
        }
    }
}
