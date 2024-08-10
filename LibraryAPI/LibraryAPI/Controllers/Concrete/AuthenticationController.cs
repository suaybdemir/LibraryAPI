using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LibraryAPI.Controllers
{

    [AllowAnonymous,Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ApplicationContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(string userName, string password)
        {

            ApplicationUser applicationUser = _userManager.FindByNameAsync(userName).Result;
            //Microsoft.AspNetCore.Identity.SignInResult signInResult;

            if (applicationUser != null && applicationUser.isActive==true) 
            {

                //signInResult = _signInManager.PasswordSignInAsync(applicationUser, password, false, false).Result;
                var signInResult = _userManager.CheckPasswordAsync(applicationUser, password).Result;
                if (signInResult == true)
                {
                    //EnableTFA(applicationUser.Id);
                    var token = GenerateJwtToken(applicationUser);
                    return Ok(new { Token = token });
                }
            }

            return Unauthorized();
        }


        private object GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]); // UTF8 kullanımı önerilir

            // Kullanıcının rollerini al
            var userRoles = _userManager.GetRolesAsync(user).Result;

            // Token claim'lerini oluştur
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName)
    };

            // Roller için foreach döngüsü kullanarak claims ekle
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var expireSeconds = Convert.ToInt32(_configuration["Jwt:Expire"]);

            var utcNow = DateTime.UtcNow;
            var expirationTimeUtc = utcNow.AddMinutes(181);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(expireSeconds),
                //Expires = expirationTimeUtc,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Generate expiration date
            var expirationDate = token.ValidTo;

            Console.WriteLine(token.ValidTo);

            return new
            {
                tokenstr = tokenHandler.WriteToken(token),
                expiration = expirationDate
            };
        }

        [Authorize(Policy ="AllUsers")]
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("ForgetPassword")]
        public ActionResult<string> ForgetPassword(string token,string userName)
        {
            ApplicationUser applicationUser = _userManager.FindByNameAsync(userName).Result;

            //string token = _userManager.GeneratePasswordResetTokenAsync(applicationUser).Result;

            MailMessage mailMessage = new MailMessage("abc@abc.com", applicationUser.Email, "password", token);
            SmtpClient smtpClient = new SmtpClient("http://smtp.domain.com");
            smtpClient.Send(mailMessage);

            return token;
        }

        [Authorize(Policy = "AllUsers")]
        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(string userName, string newPassword)
        {

            ApplicationUser applicationUser = _userManager.FindByNameAsync(userName).Result;
            string token = _userManager.GeneratePasswordResetTokenAsync(applicationUser).Result;

            try
            {
                _userManager.ResetPasswordAsync(applicationUser, token, newPassword).Wait();
            }
            catch
            {
                return Unauthorized();
            }


            return Ok();
        }
    }
}
