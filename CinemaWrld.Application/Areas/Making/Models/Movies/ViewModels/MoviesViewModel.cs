using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Movies.ViewModels
{
    public class MoviesViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }

       

        public string Genre { get; set; }




        [DisplayName("Age restricted")]
        public bool IsAgeRestricted { get; set; }

        [DisplayName("Release year")]
        public int ReleaseYear { get; set; }

        [DisplayName("Duration (minutes)")]
        public int Duration { get; set; }

        [DisplayName("Premiere date")]
        public DateTime PremiereDate { get; set; }


        [DisplayName("Last projection date")]
        public DateTime? LastProjectionDate { get; set; }


        public string Description { get; set; }



        [DisplayName("Cinema name")]
        public string CinemaName { get; set; }
    }
}
