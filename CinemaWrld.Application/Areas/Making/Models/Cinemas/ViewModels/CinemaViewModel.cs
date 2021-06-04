using CinemaWrld.Application.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Cinemas.ViewModels
{
    public class CinemaViewModel
    {



        public int Id { get; set; }

        public string Name { get; set; }


        public string Location { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }


    }



}

