using CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.BindingModels;
using CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels;
using CinemaWrld.Application.Constants;
using CinemaWrld.Application.Data.Models;
using CinemaWrld.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Controllers
{
    public class MoviesController : MakingController
    {
        private readonly IMoviesService moviesService;
        private readonly ICinemasService cinemasService;
        private readonly IMovieUsersService movieUsersService;
        private readonly UserManager<ApplicationUser> userManager;

        public MoviesController(IMoviesService moviesService, ICinemasService cinemasService, IMovieUsersService movieUsersService, UserManager<ApplicationUser> userManager)
        {
            this.moviesService = moviesService;
            this.cinemasService = cinemasService;
            this.movieUsersService = movieUsersService;
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<GetAllMoviesViewModel> movies = this.moviesService.GetAll();

            return this.View(movies);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            MoviesViewModel movies = this.moviesService.GetById(id);

            bool isMovieNull = movies == null;
            if (isMovieNull)
            {
                return this.RedirectToAction("index");
            }
            return this.View(movies);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            IEnumerable<CinemasIdNameViewModel> cinemas = this.moviesService.GetByName();

            bool areCinemasEmpty = cinemas.Count() == 0;

            if (areCinemasEmpty)
            {
                return this.RedirectToAction("index");
            }

            this.ViewBag.cinemas = cinemas;

            return this.View();
            
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(CreateMovieBindingModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.RedirectToAction("create");
            }

            await this.moviesService.CreateAsync(model);

            return this.RedirectToAction("index");
        }


        [HttpGet]
        [Authorize]

        public IActionResult Update(int id)
        {

            UpdateMovieBindingModel movie = this.moviesService.UpdateById(id);

            IEnumerable<CinemasIdNameViewModel> cinemas = this.moviesService.GetByName();

            bool isMovieNull = movie == null;
            bool areCinemasEmpty = cinemas.Count() == 0;

            if (isMovieNull || areCinemasEmpty)
            {
                return this.RedirectToAction("index");
            }

            ViewBag.cinemas = cinemas;

            return this.View(movie);
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdateMovieBindingModel model)
        {

            if (this.ModelState.IsValid == false)
            {
                return this.View(model);
            }
            await this.moviesService.UpdateAsync(model);

            return this.RedirectToAction("index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.moviesService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }


        [Authorize]
        public async Task<IActionResult> Enroll(int id)
        {
            ApplicationUser currentUser = await this.userManager.GetUserAsync(this.User);

            bool isEnrolled = await this.movieUsersService.EnrollUserToVoteAsync(currentUser.Id, id);

            if (isEnrolled)
            {
                this.TempData[NotificationsConstants.SUCCESS_NOTIFICATION] = NotificationsConstants.SUCCESSFULLY_VOTED_MOVIE;
            }
            else
            {
                this.TempData[NotificationsConstants.WARNING_NOTIFICATION] = ExceptionConstants.ALREADY_VOTED_MOVIE;
            }

            return this.RedirectToAction("index");

        }

        [Authorize]
        public async Task<IActionResult> Disenroll(int id)
        {
            ApplicationUser currentUser = await this.userManager.GetUserAsync(this.User);

            bool isEnrolled = await this.movieUsersService.RemoveUserVoteAsync(currentUser.Id, id);

            if (isEnrolled)
            {
                this.TempData[NotificationsConstants.SUCCESS_NOTIFICATION] = NotificationsConstants.SUCCESSFULLY_UNVOTED_MOVIE;
            }

            else
            {
                this.TempData[NotificationsConstants.WARNING_NOTIFICATION] = ExceptionConstants.ALREADY_UNVOTED_MOVIE;
            }

            return this.RedirectToAction("index");
        }
    }
}
