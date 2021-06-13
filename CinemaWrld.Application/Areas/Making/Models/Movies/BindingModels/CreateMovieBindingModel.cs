using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Areas.Making.Models.Movies.BindingModels
{
    public class CreateMovieBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Title { get; set; }




        public string Genre { get; set; }




        [Required]
        [DisplayName("Age restricted")]
        public bool IsAgeRestricted { get; set; }

        [Required]
        [Range(1888, 2030)]
        [DisplayName("Release year")]
        public int ReleaseYear { get; set; }

        [Required]
        [DisplayName("Duration (minutes)")]
        [Range(60, 220)]
        public int Duration { get; set; }

        [Required]
        [DisplayName("Premiere date")]
        public DateTime PremiereDate { get; set; }


        [DisplayName("Last projection date")]
        public DateTime? LastProjectionDate { get; set; }


        public string Description { get; set; }


        [Required]
        [DisplayName("Cinema name")]
        public int CinemaId { get; set; }
    }
}
