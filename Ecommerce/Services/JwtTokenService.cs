using Ecommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IJwtTokenService
    {
        string CreateToken(UserApp user);
    }
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserApp> _userManager;

        public JwtTokenService(IConfiguration configuration, UserManager<UserApp> userManager) 
            => (_configuration, _userManager) = (configuration, userManager);
      

        public string CreateToken(UserApp user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            List<Claim> claims = new List<Claim>()
            {
                new Claim("email", user.Email)
                //,
                //new Claim("photo", user.Photo)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JwtKey")));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(1000),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
