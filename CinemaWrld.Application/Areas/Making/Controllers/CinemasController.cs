using CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Controllers
{
    [Area("Making")]
    public class CinemasController : Controller
    {

        private ApplicationDbContext dbContex;
        private readonly IWebHostEnvironment hostEnvironment;

        public CinemasController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            dbContex = dbContext;
            this.hostEnvironment = hostEnvironment;
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




            return View(cinemasViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCinemaBindingModel model)
        {

            Cinema cinema = new Cinema();
            cinema.Name = model.Name;
            cinema.Location = model.Location;
            cinema.PhoneNumber = model.PhoneNumber;


            //if (model.ImageFile != null)
            //{

            //    string wwwRootPath = hostEnvironment.WebRootPath;
            //    string fileName = Path.GetFileNameWithoutExtension(cinema.ImageFile.FileName);
            //    string extension = Path.GetExtension(cinema.ImageFile.FileName);
            //    cinema.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            //    using (var fileStream = new FileStream(path, FileMode.Create))
            //    {
            //        await cinema.ImageFile.CopyToAsync(fileStream);
            //    }

            await dbContex.Cinemas.AddAsync(cinema);
            dbContex.SaveChanges();






            return RedirectToAction("index");

        }



    }
}

