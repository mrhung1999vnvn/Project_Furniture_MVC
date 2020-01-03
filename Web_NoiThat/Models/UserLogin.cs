using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_NoiThat.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Email is required")]
        [StringLength(254)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        public UserLogin()
        {

        }

    }
}