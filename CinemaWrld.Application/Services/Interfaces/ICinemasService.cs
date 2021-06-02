using CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services.Interfaces
{
    public interface ICinemasService
    {
        IEnumerable<CinemaViewModel> GetAll();

        Cinema GetById(int id);

        CinemaViewModel GetForViewById(int id);

        Cinema GetByName(string name);


        Task CreateAsync(CreateCinemaBindingModel model);

        //UpdateCinemaBindingModel UpdateById(int id);
        Task UpdateAsync(UpdateCinemaBindingModel model);

        Task DeleteAsync(int id);


    }
}
