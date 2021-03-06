using System;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Data.Seed.Seeders.Interfaces
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
