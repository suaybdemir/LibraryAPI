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
    public class LibraryRepresentativeBookStocksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LibraryRepresentativeBookStocksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/LibraryRepresentativeBookStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryRepresentativeBookStock>>> GetLibraryRepresentativeBookStocks()
        {
          if (_context.LibraryRepresentativeBookStock == null)
          {
              return NotFound();
          }
            return await _context.LibraryRepresentativeBookStock.ToListAsync();
        }

        // GET: api/LibraryRepresentativeBookStocks/5
        [HttpGet("libraryName")]
        public async Task<ActionResult<LibraryRepresentativeBookStock>> GetLibraryRepresentativeBookStock(string libraryName,int representativeBookId)
        {
          if (_context.LibraryRepresentativeBookStock == null)
          {
              return NotFound();
          }
            var libraryRepresentativeBookStock = await _context.LibraryRepresentativeBookStock
                .FirstOrDefaultAsync(lrbs=>lrbs.RepresentativeBookId == representativeBookId && lrbs.LibraryName == libraryName);

            if (libraryRepresentativeBookStock == null)
            {
                return NotFound();
            }

            return libraryRepresentativeBookStock;
        }

        // PUT: api/LibraryRepresentativeBookStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{libraryName}")]
        public async Task<IActionResult> PutLibraryRepresentativeBookStock(string libraryName,int representativeBookId, LibraryRepresentativeBookStock libraryRepresentativeBookStock)
        {
            if (libraryName != libraryRepresentativeBookStock.LibraryName)
            {
                return BadRequest();
            }

            libraryRepresentativeBookStock.RepresentativeBookId = representativeBookId;
            _context.Entry(libraryRepresentativeBookStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryRepresentativeBookStockExists(libraryName))
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

        // POST: api/LibraryRepresentativeBookStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibraryRepresentativeBookStock>> PostLibraryRepresentativeBookStock(LibraryRepresentativeBookStock libraryRepresentativeBookStock)
        {
          if (_context.LibraryRepresentativeBookStock == null)
          {
              return Problem("Entity set 'ApplicationContext.LibraryRepresentativeBookStock'  is null.");
          }
            _context.LibraryRepresentativeBookStock.Add(libraryRepresentativeBookStock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibraryRepresentativeBookStockExists(libraryRepresentativeBookStock.LibraryName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibraryRepresentativeBookStock", new { id = libraryRepresentativeBookStock.LibraryName }, libraryRepresentativeBookStock);
        }

        // DELETE: api/LibraryRepresentativeBookStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryRepresentativeBookStock(string id,int representativeBookId)
        {
            if (_context.LibraryRepresentativeBookStock == null)
            {
                return NotFound();
            }
            var libraryRepresentativeBookStock = await _context.LibraryRepresentativeBookStock
                .FirstOrDefaultAsync(lrbs=>lrbs.LibraryName == id && lrbs.RepresentativeBookId == representativeBookId);
            if (libraryRepresentativeBookStock == null)
            {
                return NotFound();
            }

            _context.LibraryRepresentativeBookStock.Remove(libraryRepresentativeBookStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryRepresentativeBookStockExists(string id)
        {
            return (_context.LibraryRepresentativeBookStock?.Any(e => e.LibraryName == id)).GetValueOrDefault();
        }
    }
}
