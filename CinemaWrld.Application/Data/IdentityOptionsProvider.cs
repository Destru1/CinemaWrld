using Microsoft.AspNetCore.Identity;

namespace CinemaWrld.Application.Data
{
    public class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;


            options.User.RequireUniqueEmail = true;
        }
    }
}
