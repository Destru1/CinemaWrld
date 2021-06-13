using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMovieUsersService movieUsersService;

        public MoviesService(ApplicationDbContext dbContext, IMovieUsersService movieUsersService)
        {
            this.dbContext = dbContext;
            this.movieUsersService = movieUsersService;
        }

        public IEnumerable<GetAllMoviesViewModel> GetAll(string userId)
        {
            IEnumerable<GetAllMoviesViewModel> movies = this.dbContext.Movies
                .Select(movies => new GetAllMoviesViewModel
                {
                    Id = movies.Id,
                    Title = movies.Title,
                    UserHasVoted = this.movieUsersService.HasAlreadyVoted(userId, movies.Id),
                    Votes = movies.Votes,
                    Year = movies.ReleaseYear,
                })
                .ToList();

            return movies;
        }


        public IEnumerable<CinemasIdNameViewModel> GetByName()
        {
            IEnumerable<CinemasIdNameViewModel> cinemas = this.dbContext.Cinemas
                .Select(cinemas => new CinemasIdNameViewModel
                {
                    Id = cinemas.Id,
                    Name = cinemas.Name,
                })
                .OrderBy(cinemas => cinemas.Id)
                .ToList();

            return cinemas;

        }

        public MoviesViewModel GetById(int id)
        {

            MoviesViewModel movies = this.dbContext.Movies
                .Select(movies => new MoviesViewModel
                {
                    Id = movies.Id,
                    Title = movies.Title,
                    Genre = movies.Genre,
                    IsAgeRestricted = movies.IsAgeRestricted,
                    ReleaseYear = movies.ReleaseYear,
                    Duration = movies.Duration,
                    PremiereDate = movies.PremiereDate,
                    LastProjectionDate = movies.LastProjectionDate,
                    Description = movies.Description,
                    CinemaName = movies.Cinema.Name,


                })
                .SingleOrDefault(movies => movies.Id == id);

            return movies;
        }


        public UpdateMovieBindingModel UpdateById(int id)
        {
            UpdateMovieBindingModel movies = this.dbContext.Movies
                .Select(m => new UpdateMovieBindingModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    IsAgeRestricted = m.IsAgeRestricted,
                    ReleaseYear = m.ReleaseYear,
                    Duration = m.Duration,
                    PremiereDate = m.PremiereDate,
                    LastProjectionDate = m.LastProjectionDate,
                    Description = m.Description,
                    CinemaId = m.Cinema.Id,

                })
                .SingleOrDefault(m => m.Id == id);

            return movies;

        }


        public bool CheckIfMovieExist(int id)
        {
            bool isMovieExisting = this.dbContext.Movies
                .Any(m => m.Id == id);


            return isMovieExisting;
        }


        public async Task CreateAsync(CreateMovieBindingModel model)
        {
            Movie movie = new Movie();
            movie.Title = model.Title;
            movie.Genre = model.Genre;
            movie.IsAgeRestricted = model.IsAgeRestricted;
            movie.ReleaseYear = model.ReleaseYear;
            movie.Duration = model.Duration;
            movie.PremiereDate = model.PremiereDate;
            movie.LastProjectionDate = model.LastProjectionDate;
            movie.Description = model.Description;
            movie.CinemaId = model.CinemaId;


            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();


        }


        public async Task UpdateAsync(UpdateMovieBindingModel model)
        {

            Movie movie = this.dbContext.Movies
                .Find(model.Id);

            bool isMovieNull = movie == null;
            if (isMovieNull)
            {
                return;
            }

            movie.Title = model.Title;
            movie.Genre = model.Genre;
            movie.IsAgeRestricted = model.IsAgeRestricted;
            movie.ReleaseYear = model.ReleaseYear;
            movie.Duration = model.Duration;
            movie.PremiereDate = model.PremiereDate;
            movie.LastProjectionDate = model.LastProjectionDate;
            movie.Description = model.Description;
            movie.CinemaId = model.CinemaId;

            this.dbContext.Movies.Update(movie);
            await this.dbContext.SaveChangesAsync();

        }


        public async Task DeleteAsync(int id)
        {
            Movie movie = new Movie();
            movie = this.dbContext.Movies.Find(id);

            bool isMovieNull = movie == null;

            if (isMovieNull)
            {
                return;
            }

            this.dbContext.Movies.Remove(movie);
            await this.dbContext.SaveChangesAsync();
        }




    }
}
