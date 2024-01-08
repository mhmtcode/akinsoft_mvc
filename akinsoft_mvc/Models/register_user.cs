using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace akinsoft_mvc.Models
{
    public class register_user
    {
        [Required(ErrorMessage = "Error Register Name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        [MinLength(8, ErrorMessage = "Min Password Lenght 8 character")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}