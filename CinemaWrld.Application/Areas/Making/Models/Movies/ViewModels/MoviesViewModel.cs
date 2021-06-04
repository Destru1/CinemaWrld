using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels
{
    public class MoviesViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }

       

        public string Genre { get; set; }


      

        
        public bool IsAgeRestricted { get; set; }

     
        public int ReleaseYear { get; set; }

       
        public int Duration { get; set; }

       
        public DateTime PremiereDate { get; set; }



        public DateTime? LastProjectionDate { get; set; }


        public string Description { get; set; }


      

        public string CinemaName { get; set; }
    }
}
