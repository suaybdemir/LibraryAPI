using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase 
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpPut("Roles")]
        public void CreateRoles()
        {
            IdentityRole identityRole = new IdentityRole("Member");

            _roleManager.CreateAsync(identityRole).Wait();

            identityRole = new IdentityRole("Worker");
            _roleManager.CreateAsync(identityRole).Wait();

            identityRole = new IdentityRole("Employee");
            _roleManager.CreateAsync(identityRole).Wait();

            identityRole = new IdentityRole("Child");
            _roleManager.CreateAsync(identityRole).Wait();

            identityRole = new IdentityRole("Donator");
            _roleManager.CreateAsync(identityRole).Wait();

        }
    }
}
