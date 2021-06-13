using System.ComponentModel;

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
