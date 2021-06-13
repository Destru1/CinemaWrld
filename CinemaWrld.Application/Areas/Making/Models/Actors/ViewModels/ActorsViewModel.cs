using System.ComponentModel;

namespace CinemaWrld.Application.Areas.Making.Models.Actors.ViewModels
{
    public class ActorsViewModel
    {
        public int Id { get; set; }


        [DisplayName("Actor Name")]


        public string Name { get; set; }


        public string Nationality { get; set; }


        public int Age { get; set; }


        [DisplayName("Playing as:")]

        public string PlayingAs { get; set; }


        [DisplayName("In movie:")]
        public string MovieName { get; set; }
    }
}
