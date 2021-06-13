using System.Collections.Generic;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels
{
    public class PaginationActorsViewModel
    {
        public IEnumerable<GetAllActorsViewModel> Actors { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
