using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Web_NoiThat.Models.Extended
{
    public class UserMetadata
    {
        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="First name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings =true,ErrorMessage ="Password is required")]
        [MinLength(6,ErrorMessage ="Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password confirm does not match")]
        public string ConfirmPassword { get; set; }
    }
    
}