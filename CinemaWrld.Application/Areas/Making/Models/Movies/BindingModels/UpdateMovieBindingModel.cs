using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Movies.BindingModels
{
    public class UpdateMovieBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]

        public string Genre { get; set; }


        public enum EGenre { Action = 0, Comedy = 1, Adventure = 2, Drama = 3, Horror = 4, Romance = 5, Other = 6 }

        [Required]
        public bool IsAgeRestricted { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime PremiereDate { get; set; }



        public DateTime? LastProjectionDate { get; set; }


        public string Description { get; set; }


        [Required]

        public int CinemaId { get; set; }
    }
}
