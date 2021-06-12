using CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services.Interfaces
{
    public interface IActorsService
    {
        PaginationActorsViewModel GetAll(int id);

        ActorsViewModel GetById(int id);

        IEnumerable<GetAllMoviesViewModel> GetByName();

        UpdateActorBindingModel UpdateById(int id);


        Task CreateAsync(CreateActorBindingModel model);

        Task UpdateAsync(UpdateActorBindingModel model);

        Task DeleteAsync(int id);
    }
}
