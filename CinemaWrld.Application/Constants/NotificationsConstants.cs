using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Constants
{
    public static class NotificationsConstants
    {
        public const string SUCCESS_NOTIFICATION = "Success";
        public const string ERROR_NOTIFICATION = "Error";
        public const string WARNING_NOTIFICATION = "Warning";
        public const string INFORMATION_NOTIFICATION = "Info";


        public const string SUCCESSFULLY_ADDED_MOVIE = "Successfully added movie!";
        public const string SUCCESSFULLY_ADDED_ACTOR = "Successfully added actor!";
        public const string SUCCESSFULLY_ADDED_DIRECTOR = "Successfully added director!";
        public const string SUCCESSFULLY_VOTED_MOVIE = "Successfully voted for this movie!";
        public const string SUCCESSFULLY_UNVOTED_MOVIE = "Successfully removed your vote for this movie!";
        public const string SUCCESSFULLY_DELETED_CINEMA = "Successfully deleted cinema!";



        public const string DATE_ERROR = "Premiere date can't be bigger than last projection date";



    }
}
