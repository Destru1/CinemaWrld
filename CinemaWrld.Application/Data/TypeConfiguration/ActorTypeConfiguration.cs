using CinemaWrld.Application.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWrld.Application.Data.TypeConfiguration
{
    public class ActorTypeConfiguration : IEntityTypeConfiguration<Actor>
    {

        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder
               .HasOne(actor => actor.Movie)
               .WithMany(movies => movies.Actors)
               .HasForeignKey(actor => actor.MovieId);
        }
    }
}
