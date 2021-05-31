using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Models
{
    public class CreateCinemaBindingModel
    {


        public int Id { get; set; }

        public string Name { get; set; }


        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Picture { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }



    }
}

