using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.BindingModels
{
    public class UpdateActorBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Actor Name")]
        [MinLength(2)]
        [MaxLength(64)]

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
