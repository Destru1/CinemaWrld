using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Directors = new HashSet<Director>();
            this.MovieUsers = new HashSet<MovieUser>();
        }

        [Key]
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

        public int Votes { get; set; }


        [Required]

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Director> Directors { get; set; }

        public virtual ICollection<MovieUser> MovieUsers { get; set; }




    }
}
