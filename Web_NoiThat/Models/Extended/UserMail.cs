using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_NoiThat.Models
{
    public class UserMail
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name ="Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [StringLength(254)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [StringLength(255), MinLength(3)]
        public string Content { get; set; }

        public UserMail()
        {

        }
    }
}