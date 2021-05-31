using CinemaWrld.Application.Data;
using CinemaWrld.Application.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Controllers
{
    public class CinemaController : Controller
    {

        private ApplicationDbContext dbcontex;

        public CinemaController(ApplicationDbContext dbContext)
        {
            this.dbcontex = dbContext;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            Cinema cinema = new Cinema();

            cinema.Name = "Palace";
            cinema.Location = "Sofia";
            cinema.PhoneNumber = "54646545464";
            cinema.Picture = "a";

            dbcontex.Cinemas.Add(cinema);
            dbcontex.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
