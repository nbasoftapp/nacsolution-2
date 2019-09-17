using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace nacsolution.Models
{
    public class UserLogin

    {

      
            [Display(Name = "Email ID")]

            [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]

            public string email { get; set; }



            [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]

            [DataType(DataType.Password)]

            public string password { get; set; }



            [Display(Name = "Remember Me")]

            public bool RememberMe { get; set; }

        }


    }
    
