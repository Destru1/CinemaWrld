using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services.Interfaces
{
    public interface IMovieUsersService
    {
        Task<bool> EnrollUserToVoteAsync(string userId, int movieId);

        Task<bool> RemoveUserVoteAsync(string userId, int movieId);

        bool HasAlreadyVoted(string userId, int movieId);


    }
}
