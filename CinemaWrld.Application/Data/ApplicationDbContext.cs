using CinemaWrld.Application.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CinemaWrld.Application.Models;
using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels;

namespace CinemaWrld.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

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

            builder
                .Entity<Cinema>()
                .HasIndex(c => c.Name)
                .IsUnique();


            builder
                .Entity<Movie>()
                .HasOne(movie => movie.Cinema)
                .WithMany(cinema => cinema.Movies)
                .HasForeignKey(movie => movie.CinemaId);


            builder
                .Entity<Actor>()
                .HasOne(actor => actor.Movie)
                .WithMany(movies => movies.Actors)
                .HasForeignKey(actor => actor.MovieId);
                
        }

        public DbSet<CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels.GetAllActorsViewModel> GetAllActorsViewModel { get; set; }

       

        


        
    }
}
