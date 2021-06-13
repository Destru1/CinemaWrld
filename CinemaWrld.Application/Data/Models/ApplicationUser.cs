using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaWrld.Application.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UsersMovie = new HashSet<MovieUser>();
        }

        public virtual ICollection<MovieUser> UsersMovie { get; set; }
    }
}
