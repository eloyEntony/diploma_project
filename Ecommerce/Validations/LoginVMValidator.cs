using Ecommerce.Data.Entities;
using Ecommerce.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Validations
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        private readonly UserManager<UserApp> _userManager;
        //https://berilkavakli.medium.com/fluent-validation-on-net-core-api-3-1-f01ff4a4c6f5
        public LoginVMValidator(UserManager<UserApp> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress()
                .DependentRules(() =>
                {
                     RuleFor(x => x.Email).Must(EmailIsExist).WithName("Email").WithMessage("User is not exist");
                });
            RuleFor(x => x.Password).NotEmpty();
            
            RuleFor(x => x).Must(UserIsExist).WithName("user").WithMessage("Email or password is incorrect");
            

        }

        

        private bool EmailIsExist(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            //_userManager.CheckPasswordAsync(user, )
            //.Users
            //.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            
            if(user != null)
                return true;

            return false;
        }

        private bool UserIsExist(LoginVM instatce)
        {
            var user = _userManager.FindByEmailAsync(instatce.Email).Result;
            var res = _userManager.CheckPasswordAsync(user, instatce.Password).Result;
                        
            return res;
        }

       
    }
}
