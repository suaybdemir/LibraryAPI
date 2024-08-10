using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Models.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers.Concrete
{
    [Authorize(Policy = "AllUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorRepresentativeBooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AuthorRepresentativeBooksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/AuthorBooks
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorRepresentativeBook>>> GetAuthorBooks()
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return NotFound();
            }
            return await _context.AuthorRepresentativeBook.ToListAsync();
        }

        // GET: api/AuthorBooks/5
        [HttpGet("AuthorId")]
        public async Task<ActionResult<AuthorRepresentativeBook>> GetAuthorBookByAuthorId(long AuthorId)
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return NotFound();
            }
            var authorBooks = await _context.AuthorRepresentativeBook
                .Where(ab => ab.AuthorsId == AuthorId)
                .ToListAsync();


            if (authorBooks == null)
            {
                return NotFound();
            }

            return Ok(authorBooks);
        }

        // GET: api/AuthorBooks/5
        [HttpGet("DoubleId")]
        public async Task<ActionResult<AuthorRepresentativeBook>> GetAuthorBookByAuthorWBookId(long AuthorId, int RepresentativeBookId)
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return NotFound();
            }
            AuthorRepresentativeBook authorBook = await _context.AuthorRepresentativeBook
                .FirstOrDefaultAsync(ab => ab.AuthorsId == AuthorId && ab.RepresentativeBooksId == RepresentativeBookId);


            if (authorBook == null)
            {
                return NotFound();
            }

            return authorBook;
        }



        // POST: api/AuthorBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<ActionResult<AuthorRepresentativeBook>> PostAuthorBook(AuthorRepresentativeBook authorBook)
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return Problem("Entity set 'ApplicationContext.AuthorBook'  is null.");
            }
            _context.AuthorRepresentativeBook.Add(authorBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorBookExists(authorBook.AuthorsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(authorBook);
        }

        // DELETE: api/AuthorBooks/5
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteAuthorRepresentativeBooksByAuthorId/{AuthorId}")]
        public async Task<IActionResult> DeleteAuthorBooksByAuthorId(long AuthorId)
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return NotFound();
            }


            var authorBooks = await _context.AuthorRepresentativeBook
       .Where(ab => ab.AuthorsId == AuthorId)
       .ToListAsync();


            if (authorBooks.Count == 0)
            {
                return NotFound();
            }

            _context.AuthorRepresentativeBook.RemoveRange(authorBooks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AuthorBooks/5
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteAuthorRepresentativeBooksByBookId/{AuthorId}")]
        public async Task<IActionResult> DeleteAuthorBooksByBookId(long AuthorId, int RepresentativeBookId)
        {
            if (_context.AuthorRepresentativeBook == null)
            {
                return NotFound();
            }
            AuthorRepresentativeBook authorBook = await _context.AuthorRepresentativeBook!
                .FirstOrDefaultAsync(ab => ab.AuthorsId == AuthorId && ab.RepresentativeBooksId == RepresentativeBookId);

            if (authorBook == null)
            {
                return NotFound();
            }

            _context.AuthorRepresentativeBook.Remove(authorBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorBookExists(long id)
        {
            return (_context.AuthorRepresentativeBook?.Any(e => e.AuthorsId == id)).GetValueOrDefault();
        }
    }
}
