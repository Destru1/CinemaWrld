using CinemaWrld.Application.Areas.Making.Models.Directors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Directors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services
{
    public class DirectorsService : IDirectorsService
    {

        private readonly ApplicationDbContext dbContext;

        public DirectorsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<GetAllDirectorsViewModel> GetAll()
        {
            IEnumerable<GetAllDirectorsViewModel> directors = this.dbContext.Directors
                .Select(directors => new GetAllDirectorsViewModel
                {
                    Id = directors.Id,
                    Name = directors.Name,
                    MovieDirecting = directors.Movie.Title,
                })
                .ToList();

            return directors;
        }

        public DirectorsViewModel GetById(int id)
        {
            DirectorsViewModel directors = this.dbContext.Directors
                .Select(directors => new DirectorsViewModel
                {
                    Id = directors.Id,
                    Name = directors.Name,
                    Nationality = directors.Nationality,
                    Age = directors.Age,
                    MovieName = directors.Movie.Title,
                })
                .SingleOrDefault(directors => directors.Id == id);

            return directors;
        }

        public IEnumerable<GetAllMoviesViewModel> GetByName()
        {
            IEnumerable<GetAllMoviesViewModel> movies = this.dbContext.Movies
                .Select(movies => new GetAllMoviesViewModel
                {
                    Id = movies.Id,
                    Title = movies.Title,
                })
                .OrderBy(movies => movies.Id)
                .ToList();

            return movies;
        }

        public UpdateDirectorBindingModel UpdateById(int id)
        {
            UpdateDirectorBindingModel directors = this.dbContext.Directors
                .Select(directors => new UpdateDirectorBindingModel
                {
                    Id = directors.Id,
                    Name = directors.Name,
                    Nationality = directors.Nationality,
                    Age = directors.Age,
                    MovieId = directors.MovieId,
                })
                .SingleOrDefault(directors => directors.Id == id);

            return directors;
        }


        public async Task CreateAsync(CreateDirectorBindingModel model)
        {
            Director director = new Director();

            director.Name = model.Name;
            director.Age = model.Age;
            director.Nationality = model.Nationality;
            director.MovieId = model.MovieId;

            await this.dbContext.Directors.AddAsync(director);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(UpdateDirectorBindingModel model)
        {
            Director director = this.dbContext.Directors.Find(model.Id);

            bool isDirectorNull = director == null;

            if (isDirectorNull)
            {
                return;
            }

            director.Name = model.Name;
            director.Age = model.Age;
            director.Nationality = model.Nationality;
            director.MovieId = model.MovieId;

            this.dbContext.Directors.Update(director);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            Director director = new Director();
            director = this.dbContext.Directors.Find(id);

            bool isDirectorNull = director == null;

            if (isDirectorNull)
            {
                return;
            }

            this.dbContext.Directors.Remove(director);
            await this.dbContext.SaveChangesAsync();


        }

    }
}
