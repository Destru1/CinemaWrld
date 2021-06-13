using CinemaWrld.Application.Areas.Making.Models.Directors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Directors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Controllers
{
    public class DirectorsController : MakingController
    {

        private readonly IDirectorsService directorsService;

        public DirectorsController(IDirectorsService directorsService)
        {
            this.directorsService = directorsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<GetAllDirectorsViewModel> directors = this.directorsService.GetAll();

            return this.View(directors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DirectorsViewModel directors = this.directorsService.GetById(id);

            bool isDirectorNull = directors == null;
            if (isDirectorNull)
            {
                return this.RedirectToAction("index");
            }
            return this.View(directors);
        }


        [HttpGet]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        public IActionResult Create()
        {
            IEnumerable<GetAllMoviesViewModel> movies = this.directorsService.GetByName();
            bool areMoviesEmpty = movies.Count() == 0;
            if (areMoviesEmpty)
            {
                return this.RedirectToAction("index");
              
            }
            this.ViewBag.movies = movies;

            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateDirectorBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.RedirectToAction("create");
            }

            await this.directorsService.CreateAsync(model);

            return this.RedirectToAction("index");
        }

        [HttpGet]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        public IActionResult Update(int id)
        {
            UpdateDirectorBindingModel director = this.directorsService.UpdateById(id);

            IEnumerable<GetAllMoviesViewModel> movies = this.directorsService.GetByName();

            bool isDirectorNull = director == null;
            bool areMoviesEmpty = movies.Count() == 0;

            if (isDirectorNull || areMoviesEmpty)
            {
                return this.RedirectToAction("index");
            }

            ViewBag.movies = movies;

            return this.View(director);

        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        public async Task<IActionResult> Update(UpdateDirectorBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(model);
            }

            await this.directorsService.UpdateAsync(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        [Authorize(Roles = RolesConstants.ADMIN_ROLE_NAME)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.directorsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }
    }
}
