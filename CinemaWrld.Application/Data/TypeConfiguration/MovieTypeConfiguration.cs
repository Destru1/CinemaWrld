using CinemaWrld.Application.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWrld.Application.Data.TypeConfiguration
{
    public class MovieTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
               .HasOne(movie => movie.Cinema)
               .WithMany(cinema => cinema.Movies)
               .HasForeignKey(movie => movie.CinemaId);
        }
    }
}
