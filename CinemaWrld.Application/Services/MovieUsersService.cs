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
       

        public MovieUsersService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
           
        }

        public async Task<bool> EnrollUserToVoteAsync(string userId, int movieId)
        {
            await CheckIfMoviesAndUsersExistAsync(userId, movieId);

            if (this.HasAlreadyVoted(userId,movieId))
            {
                return false;
            }
           

            MovieUser movieUser = new MovieUser()
            {
                UserId = userId,
                MovieId = movieId,
            };
            await AddVoteAsync(movieId);
            await this.dbContext.MoviesUsers.AddAsync(movieUser);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public bool HasAlreadyVoted(string userId, int movieId)
        {
            MovieUser vote = this.GetVote(userId, movieId);

            bool isVoted = vote != null;

            return isVoted;
        }

        public async Task<bool> RemoveUserVoteAsync(string userId, int movieId)
        {
            await CheckIfMoviesAndUsersExistAsync(userId, movieId);

            if (this.HasAlreadyVoted(userId, movieId) == false)
            {
                return false;
            }

            MovieUser vote = this.GetVote(userId, movieId);

            await RemoveVoteAsync(movieId);
            this.dbContext.MoviesUsers.Remove(vote);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private async Task AddVoteAsync(int movieId)
        {
            Movie movie = this.dbContext.Movies
                .SingleOrDefault(movie => movie.Id == movieId);
            movie.Votes += 1;

            this.dbContext.Update(movie);
            await this.dbContext.SaveChangesAsync();
        }

        private async Task RemoveVoteAsync(int movieId)
        {
            Movie movie = this.dbContext.Movies
                .SingleOrDefault(movie => movie.Id == movieId);
            movie.Votes -= 1;

            this.dbContext.Update(movie);
            await this.dbContext.SaveChangesAsync();

        }

        private async Task CheckIfMoviesAndUsersExistAsync(string userId, int movieId)
        {

            bool isMovieExisting = this.dbContext.Movies.Any(m => m.Id == movieId);

            if (isMovieExisting == false)
            {
                throw new ArgumentException(ExceptionConstants.NOT_EXISTING_MOVIE_ERROR_MESSAGE);
            }

            if (await this.userManager.FindByIdAsync(userId) == null)
            {
                throw new AggregateException(ExceptionConstants.NOT_EXISTING_USER_ERROR_MESSAGE);
            }
        }

        private MovieUser GetVote(string userId, int movieId)
        {
          MovieUser vote = this.dbContext.MoviesUsers
                .FirstOrDefault(mu => mu.UserId == userId && mu.MovieId == movieId);

            return vote;
        }
    }
}
