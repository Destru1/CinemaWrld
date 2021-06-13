using CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services
{
    public class ActorsService : IActorsService
    {
        private const int ACTORS_PER_PAGE = 4;

        private readonly ApplicationDbContext dbContext;

        public ActorsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PaginationActorsViewModel GetAll(int page)
        {
            if (page < 1)
            {
                page = 1;
            }

            int pageMultiplier = page - 1;
            IEnumerable<GetAllActorsViewModel> actors = this.dbContext.Actors
                .Select(actors => new GetAllActorsViewModel
                {
                    Id = actors.Id,
                    Name = actors.Name,
                    MovieName = actors.Movie.Title,
                    PlayingAs = actors.PlayingAs,


                })
                .Skip(pageMultiplier * ACTORS_PER_PAGE)
                .Take(ACTORS_PER_PAGE)
                .ToList();

            int totalPages = (int)Math.Ceiling(this.dbContext.Actors.Count() / (double)ACTORS_PER_PAGE);

            PaginationActorsViewModel paginationActors = new PaginationActorsViewModel()
            {
                Actors = actors,
                CurrentPage = page,
                TotalPages = totalPages,
            };


            return paginationActors;
        }

        public ActorsViewModel GetById(int id)
        {
            ActorsViewModel actors = this.dbContext.Actors
                .Select(actors => new ActorsViewModel
                {
                    Id = actors.Id,
                    Name = actors.Name,
                    Nationality = actors.Nationality,
                    Age = actors.Age,
                    PlayingAs = actors.PlayingAs,
                    MovieName = actors.Movie.Title
                })
                .SingleOrDefault(actors => actors.Id == id);

            return actors;
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

        public UpdateActorBindingModel UpdateById(int id)
        {
            UpdateActorBindingModel actors = this.dbContext.Actors
                .Select(actors => new UpdateActorBindingModel
                {
                    Id = actors.Id,
                    Name = actors.Name,
                    Nationality = actors.Nationality,
                    Age = actors.Age,
                    PlayingAs = actors.PlayingAs,
                    MovieId = actors.MovieId,
                })
                .SingleOrDefault(actors => actors.Id == id);

            return actors;
        }

        public async Task CreateAsync(CreateActorBindingModel model)
        {
            Actor actor = new Actor();
            actor.Name = model.Name;
            actor.Nationality = model.Nationality;
            actor.Age = model.Age;
            actor.PlayingAs = model.PlayingAs;
            actor.MovieId = model.MovieId;

            await this.dbContext.Actors.AddAsync(actor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateActorBindingModel model)
        {
            Actor actor = this.dbContext.Actors.Find(model.Id);

            bool isAactorNull = actor == null;
            if (isAactorNull)
            {
                return;
            }
            actor.Name = model.Name;
            actor.Nationality = model.Nationality;
            actor.Age = model.Age;
            actor.PlayingAs = model.PlayingAs;
            actor.MovieId = model.MovieId;

            this.dbContext.Actors.Update(actor);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            Actor actor = new Actor();
            actor = this.dbContext.Actors.Find(id);

            bool isAactorNull = actor == null;
            if (isAactorNull)
            {
                return;
            }

            this.dbContext.Actors.Remove(actor);
            await this.dbContext.SaveChangesAsync();

        }
    }
}
