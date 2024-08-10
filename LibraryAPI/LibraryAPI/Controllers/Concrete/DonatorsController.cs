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

namespace LibraryAPI.Controllers.Concrete
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DonatorsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DonatorsController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Donators
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donator>>> GetDonators()
        {
          if (_context.Donators == null)
          {
              return NotFound();
          }
            return await _context.Donators.ToListAsync();
        }

        // GET: api/Donators/5
        [Authorize(Roles = "Admin,Employee,Donator")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Donator>> GetDonator(string id)
        {
          if (_context.Donators == null)
          {
              return NotFound();
          }
            var donator = await _context.Donators.FindAsync(id);

            if (donator == null)
            {
                return NotFound();
            }

            return donator;
        }

        // PUT: api/Donators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee,Donator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonator(string id, Donator donator)
        {
            if (id != donator.Id)
            {
                return BadRequest();
            }

            _context.Entry(donator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonatorExists(id))
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

        // POST: api/Donators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<ActionResult<Donator>> PostDonator(Donator donator)
        {
          if (_context.Donators == null)
          {
              return Problem("Entity set 'ApplicationContext.Donators'  is null.");
          }
            _userManager.CreateAsync(donator.ApplicationUser!, donator.ApplicationUser!.Password).Wait();
            _userManager.AddToRoleAsync(donator.ApplicationUser, "Donator").Wait();
            donator.Id = donator.ApplicationUser!.Id;
            donator.ApplicationUser = null;
         
            _context.Donators.Add(donator);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonatorExists(donator.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonator", new { id = donator.Id }, donator);
        }

        // DELETE: api/Donators/5
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonator(string id)
        {
            if (_context.Donators == null)
            {
                return NotFound();
            }
            var donator = await _context.Donators.FindAsync(id);
            if (donator == null)
            {
                return NotFound();
            }

            _context.Donators.Remove(donator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonatorExists(string id)
        {
            return (_context.Donators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
