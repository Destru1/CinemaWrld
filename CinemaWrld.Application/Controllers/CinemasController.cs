using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Controllers
{
    public class CinemasController : Controller
    {

        private ApplicationDbContext dbContex;

        public CinemasController(ApplicationDbContext dbContext)
        {
            this.dbContex = dbContext;
        }

        public IActionResult Index()
        {
            CinemasViewModel cinemasViewModel = new CinemasViewModel();

            List<CinemaViewModel> cinemaInfo = dbContex.Cinemas
                .Select(cinemaInfo => new CinemaViewModel
                {
                    Name = cinemaInfo.Name,
                    Location = cinemaInfo.Location,
                    PhoneNumber = cinemaInfo.PhoneNumber
                })
                .ToList();

            
            

            cinemasViewModel.Cinemas = cinemaInfo;
           



            return this.View(cinemasViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCinemaBindingModel model)
        {
            Cinema cinema = new Cinema();
            cinema.Name = model.Name;
            cinema.Location = model.Location;
            cinema.PhoneNumber = model.PhoneNumber;

           // cinema.Picture = model.ImageFile;


            dbContex.Cinemas.Add(cinema);
            dbContex.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
