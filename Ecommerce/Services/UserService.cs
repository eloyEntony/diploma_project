using Ecommerce.Constants;
using Ecommerce.Data.Entities;
using Ecommerce.Models;
using Ecommerce.Models.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IUserService
    {
        Task<AuthResponse> LoginAsync(LoginVM model);
        Task<AuthResponse> RegisterAsync(RegisterVM model);

    }

    public class UserService : IUserService
    {
        //private readonly AppSettings _appSettings;
        private readonly UserManager<UserApp> _userManager;
        //private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(UserManager<UserApp> userManager, IJwtTokenService jwtTokenService) 
            => (_userManager, _jwtTokenService) = (userManager, jwtTokenService);
      
        public async Task<AuthResponse> LoginAsync(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                // authentication successful so generate jwt token
                var token = _jwtTokenService.CreateToken(user);
                return new AuthResponse(token);
            }

            // return null if user not found
            //if (user == null)
                return null;

            
        }

        public async Task<AuthResponse> RegisterAsync(RegisterVM model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            //if (userExists != null)
            //    return new RegisterResponse("Error", "User already exists!");

            UserApp user = new UserApp()
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),               
            };
            var result =  _userManager.CreateAsync(user, model.Password).Result;
            result =  _userManager.AddToRoleAsync(user, Roles.Admin).Result;
           

            //if (!result.Succeeded)
            //    return new RegisterResponse("Error", "User creation failed! Please check user details and try again.");
            var token = _jwtTokenService.CreateToken(user);

            return new AuthResponse(token);
        }
    }

}
