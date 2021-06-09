using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Data.Seed.Seeders.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Data.Seed.Seeders
{
    public class UsersSeeder : ISeeder
    {

    


        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            ApplicationUser user = new ApplicationUser
            {
                UserName = UsersConstants.USER_USERNAME,
                Email = UsersConstants.USER_EMAIL,
            };

            ApplicationUser admin = new ApplicationUser
            {
                UserName = UsersConstants.ADMIN_USERNAME,
                Email = UsersConstants.ADMIN_EMAIL,
            };

            await userManager.CreateAsync(user, UsersConstants.USER_PASSWORD);
            await userManager.CreateAsync(admin, UsersConstants.ADMIN_PASSWORD);

            await userManager.AddToRoleAsync(user, RolesConstants.USER_ROLE_NAME);
            await userManager.AddToRoleAsync(admin, RolesConstants.ADMIN_ROLE_NAME);
        }
    }
}
