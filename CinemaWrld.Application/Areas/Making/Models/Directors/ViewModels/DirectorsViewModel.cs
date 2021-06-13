using System.ComponentModel;

namespace CinemaWrld.Application.Areas.Making.Models.Directors.ViewModels
{
    public class DirectorsViewModel
    {

        public int Id { get; set; }

        [DisplayName("Director full name")]
        public string Name { get; set; }


        public int Age { get; set; }


        public string Nationality { get; set; }


        [DisplayName("Directing movie")]
        public string MovieName { get; set; }
    }
}
