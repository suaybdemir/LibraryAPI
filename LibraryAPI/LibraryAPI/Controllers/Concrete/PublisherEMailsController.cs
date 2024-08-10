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
    public class PublisherEMailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PublisherEMailsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PublisherEMails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherEMail>>> GetPublisherEMail()
        {
          if (_context.PublisherEMail == null)
          {
              return NotFound();
          }
            return await _context.PublisherEMail.ToListAsync();
        }

        // GET: api/PublisherEMails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherEMail>> GetPublisherEMail(string id)
        {
          if (_context.PublisherEMail == null)
          {
              return NotFound();
          }
            var publisherEMail = await _context.PublisherEMail.FindAsync(id);

            if (publisherEMail == null)
            {
                return NotFound();
            }

            return publisherEMail;
        }

        // PUT: api/PublisherEMails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisherEMail(int id, PublisherEMail publisherEMail)
        {
            if (id != publisherEMail.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisherEMail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherEMailExists(id))
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

        // POST: api/PublisherEMails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublisherEMail>> PostPublisherEMail(PublisherEMail publisherEMail)
        {
          if (_context.PublisherEMail == null)
          {
              return Problem("Entity set 'ApplicationContext.PublisherEMail'  is null.");
          }
            _context.PublisherEMail.Add(publisherEMail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublisherEMailExists(publisherEMail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublisherEMail", new { id = publisherEMail.Id }, publisherEMail);
        }

        // DELETE: api/PublisherEMails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherEMail(string id)
        {
            if (_context.PublisherEMail == null)
            {
                return NotFound();
            }
            var publisherEMail = await _context.PublisherEMail.FindAsync(id);
            if (publisherEMail == null)
            {
                return NotFound();
            }

            _context.PublisherEMail.Remove(publisherEMail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherEMailExists(int id)
        {
            return (_context.PublisherEMail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
