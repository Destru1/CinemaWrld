using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels
{
    public class GetAllActorsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string MovieName { get; set; }

        public string PlayingAs { get; set; }


    }
}
