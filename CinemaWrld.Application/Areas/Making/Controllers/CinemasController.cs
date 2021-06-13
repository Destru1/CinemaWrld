using CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Controllers
{
   
    public class CinemasController : MakingController
    {

        
        //private readonly IWebHostEnvironment hostEnvironment;
        private readonly ICinemasService cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
          
            
            this.cinemasService = cinemasService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CinemaViewModel> cinemaInfo = this.cinemasService.GetAll();

            CinemasViewModel cinemasViewModel = new CinemasViewModel();

            cinemasViewModel.Cinemas = cinemaInfo;




            return this.View(cinemasViewModel);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            CinemaViewModel cinema = this.cinemasService.GetForViewById(id);

            bool isCinemaNull = cinema == null;
            if (isCinemaNull)
            {
                return this.RedirectToRoute("index");
            }

            return this.View(cinema);
        }

        [HttpGet]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(CreateCinemaBindingModel model)
        {

            Cinema cinemaFormDb = this.cinemasService.GetByName(model.Name);

            bool isCinemaInDb = cinemaFormDb != null;
            if (isCinemaInDb)
            {
                return this.RedirectToAction("index");

             
            }
            await this.cinemasService.CreateAsync(model);

            return this.RedirectToAction("index");


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


        }


        [HttpGet]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        public IActionResult Update(int id)
        {
            CinemaViewModel  cinema = this.cinemasService.GetForViewById(id);

            bool isCinemaNull = cinema == null;

            if (isCinemaNull)
            {
                return RedirectToAction("index");
            }
            return this.View(cinema);

        }


        [HttpPost]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdateCinemaBindingModel model)
        {
            await this.cinemasService.UpdateAsync(model);

            return this.RedirectToAction("index");

        }


        [HttpGet]
        [Authorize(Roles = RolesConstants.ADMIN_ROLE_NAME)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.cinemasService.DeleteAsync(id);

            this.TempData[NotificationsConstants.SUCCESS_NOTIFICATION] = NotificationsConstants.SUCCESSFULLY_DELETED_CINEMA;

            return this.RedirectToAction("index");
        }




    }
}

