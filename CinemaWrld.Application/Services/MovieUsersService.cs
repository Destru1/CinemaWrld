using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services
{
    public class MovieUsersService : IMovieUsersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMoviesService moviesService;

        public MovieUsersService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IMoviesService moviesService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.moviesService = moviesService;
        }


        public async Task<bool> EnrollUserToVoteAsync(string userId, int movieId)
        {
            await ChekIfUserAndMovieExsistAsync(userId, movieId);

            if (this.HasAlreadyVoted(userId,movieId) == false)
            {
                throw new InvalidOperationException(ExceptionConstants.ALREADY_VOTED_MOVIE);
            }

            MovieUser movieUser = new MovieUser()
            {
                UserId = userId,
                MovieId = movieId,
            };

            await AddVote(movieId);
            await this.dbContext.MoviesUsers.AddAsync(movieUser);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveUserVoteAsync(string userId, int movieId)
        {
            await ChekIfUserAndMovieExsistAsync(userId, movieId);
            if (this.HasAlreadyVoted(userId,movieId) == false)
            {
                return false;
            }

            MovieUser movieUser = GetVotes(userId, movieId);
            await Unvote(movieId);

            this.dbContext.MoviesUsers.Remove(movieUser);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private  async Task Unvote(int movieId)
        {
            Movie movie = this.dbContext.Movies
                 .SingleOrDefault(movie => movie.Id == movieId);

            movie.Votes -= 1;

            this.dbContext.Update(movie);
            await this.dbContext.SaveChangesAsync();
        }

        private async Task AddVote(int movieId)
        {
            Movie movie = this.dbContext.Movies
                  .SingleOrDefault(movie => movie.Id == movieId);
            movie.Votes += 1;

            this.dbContext.Update(movie);
            await this.dbContext.SaveChangesAsync();
        }

        public bool HasAlreadyVoted(string userId, int movieId)
        {
            MovieUser vote = GetVotes(userId, movieId);

                bool isVoted = vote != null;

            return isVoted;
        }

        private MovieUser GetVotes(string userId, int movieId)
        {
            MovieUser userMovie = this.dbContext.MoviesUsers
                 .FirstOrDefault(userMovie => userMovie.UserId == userId && userMovie.MovieId == movieId);

            return userMovie;
        }

        private async Task ChekIfUserAndMovieExsistAsync(string userId, int movieId)
        {
            bool isMovieExisting = this.moviesService.CheckIfMovieExist(movieId);

            if (isMovieExisting)
            {
                throw new ArgumentException(ExceptionConstants.NOT_EXISTING_MOVIE_ERROR_MESSAGE);
            }

            if (await this.userManager.FindByIdAsync(userId) == null)
            {
                throw new ArgumentException(ExceptionConstants.NOT_EXISTING_USER_ERROR_MESSAGE);
            }
        }
    }
}
