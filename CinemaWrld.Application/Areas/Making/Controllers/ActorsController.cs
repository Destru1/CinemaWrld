using CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Controllers
{
    public class ActorsController : MakingController
    {
        private readonly IActorsService actorsService;
     

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<GetAllActorsViewModel> actors = this.actorsService.GetAll();

            return this.View(actors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ActorsViewModel actors = this.actorsService.GetById(id);

            bool isActorNull = actors == null;
            if (isActorNull)
            {
                return this.RedirectToAction("index");
            }
            return this.View(actors);
        }

        [HttpGet]

        public IActionResult Create()
        {
            IEnumerable<GetAllMoviesViewModel> movies = this.actorsService.GetByName();

            bool areMoviesEmpty = movies.Count() == 0;

            if (areMoviesEmpty)
            {
                return this.RedirectToAction("index");
            }

            this.ViewBag.movies = movies;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActorBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.RedirectToAction("create");
            }

            await this.actorsService.CreateAsync(model);

            return this.RedirectToAction("index");
        }

        [HttpGet]

        public IActionResult Update(int id)
        {
            UpdateActorBindingModel actor = this.actorsService.UpdateById(id);

            IEnumerable<GetAllMoviesViewModel> movies = this.actorsService.GetByName();

            bool isActorNull = actor == null;
            bool areMoviesEmpty = movies.Count() == 0;

            if (isActorNull || areMoviesEmpty)
            {
                return this.RedirectToAction("index");
            }
            ViewBag.movies = movies;

            return this.View(actor);

        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateActorBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(model);
            }
            await this.actorsService.UpdateAsync(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.actorsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }

    }
}
