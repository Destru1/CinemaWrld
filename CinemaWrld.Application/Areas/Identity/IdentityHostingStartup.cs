using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CinemaWrld.Application.Areas.Identity.IdentityHostingStartup))]
namespace CinemaWrld.Application.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}