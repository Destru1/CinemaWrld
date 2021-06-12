using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Directors.ViewModels
{
    public class GetAllDirectorsViewModel
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        [DisplayName("Directing movie")]
        public string MovieDirecting { get; set; }
    }
}
