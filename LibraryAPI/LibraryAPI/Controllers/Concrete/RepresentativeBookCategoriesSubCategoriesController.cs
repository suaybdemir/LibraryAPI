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
    public class RepresentativeBookCategoriesSubCategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RepresentativeBookCategoriesSubCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RepresentativeBookCategoriesSubCategories
        [HttpGet("GetRepresentativeBookCategorySubCategories")]
        public async Task<ActionResult<IEnumerable<RepresentativeBookCategorySubCategory>>> GetRepresentativeBookCategorySubCategories()
        {
          if (_context.RepresentativeBookCategorySubCategory == null)
          {
              return NotFound();
          }
            return await _context.RepresentativeBookCategorySubCategory.ToListAsync();
        }

        [HttpGet("GetByCategoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<RepresentativeBookCategorySubCategory>>> GetByCategoryId(short categoryId)
        {
            if (_context.RepresentativeBookCategorySubCategory == null)
            {
                return Problem("Entity set 'ApplicationContext.RepresentativeBookCategorySubCategory' is null.");
            }

            var result = await _context.RepresentativeBookCategorySubCategory
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }




        // POST: api/RepresentativeBookCategoriesSubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostRepresentativeBookCategorySubCategory")]
        public async Task<ActionResult<RepresentativeBookCategorySubCategory>> PostRepresentativeBookCategorySubCategory(RepresentativeBookCategorySubCategory representativeBookCategorySubCategory)
        {
          if (_context.RepresentativeBookCategorySubCategory == null)
          {
              return Problem("Entity set 'ApplicationContext.RepresentativeBookCategorySubCategory'  is null.");
          }
            _context.RepresentativeBookCategorySubCategory.Add(representativeBookCategorySubCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepresentativeBookCategorySubCategoryExists(representativeBookCategorySubCategory.RepresentativeBookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepresentativeBookCategorySubCategory", new { id = representativeBookCategorySubCategory.RepresentativeBookId }, representativeBookCategorySubCategory);
        }

        // DELETE: api/RepresentativeBookCategoriesSubCategories/5
        [HttpDelete("DeleteRepresentativeBookCategorySubCategory")]
        public async Task<IActionResult> DeleteRepresentativeBookCategorySubCategory(int representativeBookId)
        {
            if (_context.RepresentativeBookCategorySubCategory == null)
            {
                return NotFound();
            }
            var representativeBookCategorySubCategory = await _context.RepresentativeBookCategorySubCategory.FirstOrDefaultAsync(a=>a.RepresentativeBookId== representativeBookId);
            if (representativeBookCategorySubCategory == null)
            {
                return NotFound();
            }

            _context.RepresentativeBookCategorySubCategory.Remove(representativeBookCategorySubCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepresentativeBookCategorySubCategoryExists(int id)
        {
            return (_context.RepresentativeBookCategorySubCategory?.Any(e => e.RepresentativeBookId == id)).GetValueOrDefault();
        }
    }
}
