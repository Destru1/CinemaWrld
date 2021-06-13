using CinemaWrld.Application.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWrld.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<MovieUser> MoviesUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured == false)

            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=CinemaWrld;Trusted_Connection=True;MultipleActiveResultSets=true");
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }

        public DbSet<CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels.CinemasIdNameViewModel> CinemasIdNameViewModel { get; set; }




    }
}
