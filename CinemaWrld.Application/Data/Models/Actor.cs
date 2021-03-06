using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Data.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [Range(1, 99)]
        public int Age { get; set; }

        [Required]
        public string PlayingAs { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }


    }
}
