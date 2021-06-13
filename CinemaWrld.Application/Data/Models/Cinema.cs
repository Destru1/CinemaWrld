using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Data.Models
{
    public class Cinema
    {
        public Cinema()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string PhoneNumber { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }
    }
}
