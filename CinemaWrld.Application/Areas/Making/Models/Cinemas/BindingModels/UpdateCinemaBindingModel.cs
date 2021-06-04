using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels
{
    public class UpdateCinemaBindingModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]

        public string Location { get; set; }

        [MinLength(8)]
        [MaxLength(20)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        //public string Picture { get; set; }

        //public IFormFile ImageFile { get; set; }
    }
}

