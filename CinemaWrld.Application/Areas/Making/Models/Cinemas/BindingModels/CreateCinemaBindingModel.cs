using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels
{
    public class CreateCinemaBindingModel
    {


        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Location { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }





    }
}

