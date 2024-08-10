using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SubCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet("GetSubCategories")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
        {
          if (_context.SubCategories == null)
          {
              return NotFound();
          }
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/SubCategories/5
        [HttpGet("GetSubCategory")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(short id)
        {
            if (_context.SubCategories == null)
            {
                return NotFound();
            }
            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return subCategory;
        }

        // PUT: api/SubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutSubCategory")]
        public async Task<IActionResult> PutSubCategory(short id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return BadRequest("ID mismatch.");
            }

            // Check if the entity exists
            var existingSubCategory = await _context.SubCategories.FindAsync(id);
            if (existingSubCategory == null)
            {
                return NotFound();
            }

            // Update only the fields that should be modified
            existingSubCategory.Name = subCategory.Name;
            // Add other fields that you want to update

            // No need to set EntityState.Modified explicitly here if using Attach()
            _context.Entry(existingSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSubCategory")]
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
        {
            if (_context.SubCategories == null)
            {
                return Problem("Entity set 'ApplicationContext.SubCategories'  is null.");
            }
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSubCategory), // The action name
                new { id = subCategory.Id }, // Route values
                subCategory); // The resource
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("DeleteSubCategory")]
        public async Task<IActionResult> DeleteSubCategory(short id)
        {
            if (_context.SubCategories == null)
            {
                return NotFound();
            }
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoryExists(short id)
        {
            return (_context.SubCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
