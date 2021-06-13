using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Data.Models
{
    public class MovieUser
    {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
