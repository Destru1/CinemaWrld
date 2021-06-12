using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels
{
    public class GetAllMoviesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public bool UserHasVoted { get; set; }

        public int Votes { get; set; }

    }
}
