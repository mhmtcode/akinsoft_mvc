using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace akinsoft_mvc.Models
{
    public class Item_Saved
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        
        public string registername { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        public string urladress { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        public int category_id { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
        [MaxLength(8, ErrorMessage = "Max Password Lenght 8 character")]
        [MinLength(8, ErrorMessage = "Min Password Lenght 8 character")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int User_id { get; set; }
    }
}