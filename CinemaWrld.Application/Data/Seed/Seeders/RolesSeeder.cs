using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Data.Seed.Seeders.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Data.Seed.Seeders
{
    public class RolesSeeder : ISeeder
    {
        public RolesSeeder()
        {

        }


        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityRole userRole = new IdentityRole
            {
                Name = RolesConstants.USER_ROLE_NAME,
            };

            IdentityRole adminRole = new IdentityRole
            {
                Name = RolesConstants.ADMIN_ROLE_NAME
            };

            await roleManager.CreateAsync(userRole);
            await roleManager.CreateAsync(adminRole);
        }
    }
}
