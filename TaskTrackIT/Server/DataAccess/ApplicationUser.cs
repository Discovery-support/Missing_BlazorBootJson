using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaskTrackIT.Server.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        [Range(1, 3, ErrorMessage = "User type must be Admin = 1, Insider = 2 & Outsider ")]
        public int UserType { get; set; }   // Admin = 1, Insider = 2 & Outsider = 3;
        //[StringLength(30)]
        //[Required]
        //public string Alias { get; set; }
    }
}
