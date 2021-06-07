using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Directors.BindingModels
{
    public class UpdateDirectorBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Director full name")]
        public string Name { get; set; }

        [Required]
        [Range(1,99)]
        public int Age { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Nationality { get; set; }

        [Required]
        [DisplayName("Directing movie")]
        public int MovieId { get; set; }
    }
}
