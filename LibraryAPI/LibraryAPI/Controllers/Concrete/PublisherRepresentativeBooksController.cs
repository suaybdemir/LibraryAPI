using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherRepresentativeBooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PublisherRepresentativeBooksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PublisherRepresentativeBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherRepresentativeBook>>> GetPublisherRepresentativeBook()
        {
          if (_context.PublisherRepresentativeBook == null)
          {
              return NotFound();
          }
            return await _context.PublisherRepresentativeBook.ToListAsync();
        }

        // GET: api/PublisherRepresentativeBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherRepresentativeBook>> GetPublisherRepresentativeBook(int id)
        {
          if (_context.PublisherRepresentativeBook == null)
          {
              return NotFound();
          }
            var publisherRepresentativeBook = await _context.PublisherRepresentativeBook.FindAsync(id);

            if (publisherRepresentativeBook == null)
            {
                return NotFound();
            }

            return publisherRepresentativeBook;
        }

        // PUT: api/PublisherRepresentativeBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisherRepresentativeBook(int id, PublisherRepresentativeBook publisherRepresentativeBook)
        {
            if (id != publisherRepresentativeBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisherRepresentativeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherRepresentativeBookExists(id))
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

        // POST: api/PublisherRepresentativeBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublisherRepresentativeBook>> PostPublisherRepresentativeBook(PublisherRepresentativeBook publisherRepresentativeBook)
        {
          if (_context.PublisherRepresentativeBook == null)
          {
              return Problem("Entity set 'ApplicationContext.PublisherRepresentativeBook'  is null.");
          }
            _context.PublisherRepresentativeBook.Add(publisherRepresentativeBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublisherRepresentativeBookExists(publisherRepresentativeBook.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublisherRepresentativeBook", new { id = publisherRepresentativeBook.Id }, publisherRepresentativeBook);
        }

        // DELETE: api/PublisherRepresentativeBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherRepresentativeBook(int id)
        {
            if (_context.PublisherRepresentativeBook == null)
            {
                return NotFound();
            }
            var publisherRepresentativeBook = await _context.PublisherRepresentativeBook.FindAsync(id);
            if (publisherRepresentativeBook == null)
            {
                return NotFound();
            }

            _context.PublisherRepresentativeBook.Remove(publisherRepresentativeBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherRepresentativeBookExists(int id)
        {
            return (_context.PublisherRepresentativeBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
