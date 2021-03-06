using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels
{
    public class CreateActorBindingModel
    {

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Actor Name")]

        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Nationality { get; set; }

        [Required]
        [Range(1, 99)]
        public int Age { get; set; }

        [Required]
        [DisplayName("Playing as :")]
        [MinLength(2)]
        [MaxLength(64)]
        public string PlayingAs { get; set; }

        [Required]
        [DisplayName("In movie:")]
        public int MovieId { get; set; }
    }
}
