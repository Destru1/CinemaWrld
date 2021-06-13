using CinemaWrld.Application.Areas.Making.Models.Directors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Directors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services.Interfaces
{
    public interface IDirectorsService
    {
        IEnumerable<GetAllDirectorsViewModel> GetAll();


        DirectorsViewModel GetById(int id);

        IEnumerable<GetAllMoviesViewModel> GetByName();

        UpdateDirectorBindingModel UpdateById(int id);

        Task CreateAsync(CreateDirectorBindingModel model);

        Task UpdateAsync(UpdateDirectorBindingModel model);

        Task DeleteAsync(int id);

    }
}
