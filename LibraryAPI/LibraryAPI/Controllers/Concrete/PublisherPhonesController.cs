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
    public class PublisherPhonesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PublisherPhonesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PublisherPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherPhone>>> GetPublisherPhone()
        {
          if (_context.PublisherPhone == null)
          {
              return NotFound();
          }
            return await _context.PublisherPhone.ToListAsync();
        }

        // GET: api/PublisherPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherPhone>> GetPublisherPhone(string id)
        {
          if (_context.PublisherPhone == null)
          {
              return NotFound();
          }
            var publisherPhone = await _context.PublisherPhone.FindAsync(id);

            if (publisherPhone == null)
            {
                return NotFound();
            }

            return publisherPhone;
        }

        // PUT: api/PublisherPhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisherPhone(int id, PublisherPhone publisherPhone)
        {
            if (id != publisherPhone.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisherPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherPhoneExists(id))
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

        // POST: api/PublisherPhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublisherPhone>> PostPublisherPhone(PublisherPhone publisherPhone)
        {
          if (_context.PublisherPhone == null)
          {
              return Problem("Entity set 'ApplicationContext.PublisherPhone'  is null.");
          }
            _context.PublisherPhone.Add(publisherPhone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublisherPhoneExists(publisherPhone.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublisherPhone", new { id = publisherPhone.Id }, publisherPhone);
        }

        // DELETE: api/PublisherPhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherPhone(string id)
        {
            if (_context.PublisherPhone == null)
            {
                return NotFound();
            }
            var publisherPhone = await _context.PublisherPhone.FindAsync(id);
            if (publisherPhone == null)
            {
                return NotFound();
            }

            _context.PublisherPhone.Remove(publisherPhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherPhoneExists(int id)
        {
            return (_context.PublisherPhone?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
