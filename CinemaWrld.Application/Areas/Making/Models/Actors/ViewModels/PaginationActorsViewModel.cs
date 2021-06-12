using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels
{
    public class PaginationActorsViewModel
    {
        public IEnumerable<GetAllActorsViewModel> Actors { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
