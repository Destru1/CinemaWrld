using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
