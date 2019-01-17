using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetVET.Models;

namespace PetVET.Controllers
{
    public class TokenController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [Route("/token")]
        [HttpPost]
        public async Task<IActionResult> Create(string userName, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Some Secure Key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.Sha256);

                var token = new JwtSecurityToken(
                    issuer: "localhost",
                    audience: "localhost",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    token = tokenString,
                });
            }

            return BadRequest("Login lub Hasło są nie poprawne"); 
        }
    }
}