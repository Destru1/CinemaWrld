using CinemaWrld.Application.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWrld.Application.Data.TypeConfiguration
{
    public class MovieUserTypeConfiguration : IEntityTypeConfiguration<MovieUser>
    {
        public void Configure(EntityTypeBuilder<MovieUser> builder)
        {
            builder
                .HasOne(mu => mu.Movie)
                .WithMany(m => m.MovieUsers)
                .HasForeignKey(mu => mu.MovieId);


            builder
                .HasOne(mu => mu.User)
                .WithMany(u => u.UsersMovie)
                .HasForeignKey(mu => mu.UserId);
        }
    }
}
