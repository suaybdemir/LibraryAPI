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
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public LibrariesController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
           
        }

        // GET: api/Libraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibraries()
        {
            if (_context.Library == null)
            {
                return NotFound();
            }
            return await _context.Library.ToListAsync();
        }

        // GET: api/Libraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
          if (_context.Library == null)
          {
              return NotFound();
          }
            var library = await _context.Library.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        //PUT: api/Libraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{libraryName}")]
        public async Task<IActionResult> PutLibrary(string libraryName, Library library)
        {
            var existingLibrary = await _context.Library!
        .FirstOrDefaultAsync(l => l.Name == libraryName);

            _context.Library!.Remove(existingLibrary);
            


            _context.Library.Add(library);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(libraryName))
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

        // POST: api/Libraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
          if (_context.Library == null)
          {
              return Problem("Entity set 'ApplicationContext.Library'  is null.");
          }
            _context.Library.Add(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.Name }, library);
        }

        // DELETE: api/Libraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            if (_context.Library == null)
            {
                return NotFound();
            }
            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Library.Remove(library);
            await _context.SaveChangesAsync();

            return NoContent();
        }

  

        private bool LibraryExists(string id)
        {
            return (_context.Library?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
