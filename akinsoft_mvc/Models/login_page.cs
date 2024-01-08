using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace akinsoft_mvc.Models
{
    public class login_page
    {
        [Required(ErrorMessage = "Error Register Name")]
       
        public string username { get; set; }

        [Required(ErrorMessage = "Error Register Name")]
       
        public string password { get; set; }
        [Required]
        public int User_id { get; set; }

    }
}