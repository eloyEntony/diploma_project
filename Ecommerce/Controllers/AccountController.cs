using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
            => (_userService) = (userService);


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            //var response = await _userService.RegisterAsync(model);

            var response = await _userService.RegisterAsync(model);


            //if (response == null)
            //return BadRequest(new { message = "Error" });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            var response = await _userService.LoginAsync(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }
}
