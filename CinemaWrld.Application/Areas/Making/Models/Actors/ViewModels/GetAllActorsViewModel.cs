using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels
{
    public class GetAllActorsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Actor Name")]
        public string Name { get; set; }

        [DisplayName("Movie name")]
        public string MovieName { get; set; }

        [DisplayName("Playing as")]
        public string PlayingAs { get; set; }


    }
}
