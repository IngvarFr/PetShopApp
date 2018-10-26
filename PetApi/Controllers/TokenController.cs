using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entities;
using PetShopApp.RestApi.Helpers;

namespace PetShopApp.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public TokenController(IUserRepository repository)
        {
            _repo = repository;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _repo.GetUsers().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
            {
                return Unauthorized();
            }

            // check if password is correct
            if (!model.Password.Equals(user.Password))
            {
                return Unauthorized();
            }

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user)
            });
        }

        // This method generates and returns a JWT token for a user.
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,               // notBefore
                               DateTime.Now.AddDays(1)));  // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}