using Ecommerce.Constants;
using Ecommerce.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public static class SeederDatabase
    {
        public static void SeedData(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<RoleApp>>();
                var result = managerRole.CreateAsync(new RoleApp
                {
                    Name = Roles.Admin
                }).Result;

                result = managerRole.CreateAsync(new RoleApp
                {
                    Name = Roles.User
                }).Result;

                string email = "admin@gmail.com";
                var user = new UserApp
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+11(111)111-11-11"
                };
                result = manager.CreateAsync(user, "Qwerty1-").Result;
                result = manager.AddToRoleAsync(user, Roles.Admin).Result;
            }
        }
    }
}

