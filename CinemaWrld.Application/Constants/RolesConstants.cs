using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Constants
{
    public  static class RolesConstants
    {
        public const string USER_ROLE_NAME = "User";
        public const string ADMIN_ROLE_NAME = "Admin";
        public const string USER_ADMIN_AUTHORISED = USER_ROLE_NAME + "," + ADMIN_ROLE_NAME;
    }
}
