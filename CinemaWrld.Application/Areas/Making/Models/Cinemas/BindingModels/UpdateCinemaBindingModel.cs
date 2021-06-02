using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Cinemas.BindingModels
{
    public class UpdateCinemaBindingModel
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        //public string Picture { get; set; }

        //public IFormFile ImageFile { get; set; }
    }
}

