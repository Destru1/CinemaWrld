using CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int page = 1)
        {
            PaginationActorsViewModel paginationActors = this.actorsService.GetAll(page);

            return this.View(paginationActors);
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
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]

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
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateActorBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.RedirectToAction("create");
            }

            this.TempData[NotificationsConstants.SUCCESS_NOTIFICATION] = NotificationsConstants.SUCCESSFULLY_ADDED_ACTOR;

            await this.actorsService.CreateAsync(model);

            return this.RedirectToAction("index");
        }

        [HttpGet]
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
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
        [Authorize(Roles = RolesConstants.USER_ADMIN_AUTHORISED)]
        [AutoValidateAntiforgeryToken]

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
        [Authorize(Roles = RolesConstants.ADMIN_ROLE_NAME)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.actorsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }

    }
}
