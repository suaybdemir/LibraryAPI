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
using System.Net.Mail;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = "Admin,Member,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public MembersController(ApplicationContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET: api/Members
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            if (_context.Members == null)
            {
                return NotFound();
            }
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("GetMember")]
        public async Task<ActionResult<Member>> GetMember(string id)
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(string id, Member member,string currentPassword)
        {
            ApplicationUser applicationUser = _userManager.FindByIdAsync(id).Result;

            if (id != member.Id)
            {
                return BadRequest();
            }


            applicationUser.Status = member.ApplicationUser!.Status;
            //..

            _userManager.UpdateAsync(applicationUser).Wait();

            if (applicationUser.Password != null)
            {
                _userManager.ChangePasswordAsync(applicationUser, currentPassword, applicationUser.Password).Wait();
            }
            member.ApplicationUser = null;

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdatePassword/{id}")]
        public async Task<IActionResult> UpdatePassword(string id,string currentPassword, string newPassword)
        {
            ApplicationUser applicationUser = _userManager.FindByIdAsync(id).Result;

            _userManager.ChangePasswordAsync(applicationUser, currentPassword, newPassword).Wait();
            
            var updateResult = await _userManager.UpdateAsync(applicationUser);
            if (!updateResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user.");
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'ApplicationContext.Members' is null.");
            }

            if (member.ApplicationUser == null)
            {
                return BadRequest("ApplicationUser must be provided.");
            }

            // Create the application user asynchronously
            var result = await _userManager.CreateAsync(member.ApplicationUser, member.ApplicationUser.Password);

            if (!result.Succeeded)
            {
                // Handle the case where user creation fails
                return BadRequest(result.Errors);
            }

            try
            {
                // Add user to role
                await _userManager.AddToRoleAsync(member.ApplicationUser, "Member");
            }
            catch (Exception ex)
            {
                // Log the exception and return a 500 status code
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the user to the role.");
            }

            // Set the member Id and clear the application user reference
            member.Id = member.ApplicationUser.Id;
            member.ApplicationUser = null;

            // Add member to the context
            _context.Members.Add(member);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Handle the case where a conflict occurs
                if (MemberExists(member.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            // Return the created member
            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }


        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(string id)
        {
            if (_context.Members == null)
            {
                return NotFound();
            }
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            var appUser = await _context.ApplicationUsers.FindAsync(id);
            appUser.isActive = false;
            _context.ApplicationUsers.Update(appUser);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        

        
        private bool MemberExists(string id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
