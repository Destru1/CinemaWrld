using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWrld.Application.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWrld.Application.Data.TypeConfiguration
{
    public class DirectorTypeConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder
                .HasOne(director => director.Movie)
                .WithMany(movies => movies.Directors)
                .HasForeignKey(director => director.MovieId);
        }
    }
}
