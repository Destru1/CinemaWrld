using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services.Interfaces
{
    public interface IMoviesService
    {
        IEnumerable<GetAllMoviesViewModel> GetAll(string currentUser);

        MoviesViewModel GetById(int id);

        UpdateMovieBindingModel UpdateById(int id);

        IEnumerable<CinemasIdNameViewModel> GetByName();
        bool CheckIfMovieExist(int id);

        Task CreateAsync(CreateMovieBindingModel model);

        Task UpdateAsync(UpdateMovieBindingModel model);

        Task DeleteAsync(int id);
    }
}
