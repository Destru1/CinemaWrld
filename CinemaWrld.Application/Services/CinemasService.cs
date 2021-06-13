using CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly ApplicationDbContext dbContext;


        public CinemasService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        public IEnumerable<CinemaViewModel> GetAll()
        {
            IEnumerable<CinemaViewModel> cinemas = this.dbContext.Cinemas
                .Select(cinema => new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Location = cinema.Location,
                    PhoneNumber = cinema.PhoneNumber,
                })
                .OrderBy(cinema => cinema.Name)
                .ToList();

            return cinemas;
        }


        public Cinema GetById(int id)
        {
            Cinema cinema = this.dbContext.Cinemas
                .SingleOrDefault(cinema => cinema.Id == id);

            return cinema;
        }


        public CinemaViewModel GetForViewById(int id)
        {
            CinemaViewModel cinema = this.dbContext.Cinemas
                .Select(c => new CinemaViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                    PhoneNumber = c.PhoneNumber,
                })
                .SingleOrDefault(c => c.Id == id);

            return cinema;

        }

        public Cinema GetByName(string name)
        {
            Cinema cinemaFromDb = this.dbContext.Cinemas
                .SingleOrDefault(c => c.Name == name);

            return cinemaFromDb;
        }


        public async Task CreateAsync(CreateCinemaBindingModel model)
        {
            Cinema cinema = new Cinema();
            cinema.Name = model.Name;
            cinema.Location = model.Location;
            cinema.PhoneNumber = model.PhoneNumber;

            await this.dbContext.Cinemas.AddAsync(cinema);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(UpdateCinemaBindingModel model)
        {
            Cinema cinema = this.GetById(model.Id);

            bool isCinemaNull = cinema == null;
            if (isCinemaNull)
            {
                return;
            }
            cinema.Name = model.Name;
            cinema.Location = model.Location;
            cinema.PhoneNumber = model.PhoneNumber;

            this.dbContext.Cinemas.Update(cinema);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Cinema cinema = this.GetById(id);

            bool isCinemaNull = cinema == null;
            if (isCinemaNull)
            {
                return;
            }
            this.dbContext.Cinemas.Remove(cinema);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
