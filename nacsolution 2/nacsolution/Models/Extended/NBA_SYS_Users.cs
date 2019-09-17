using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace nacsolution.Models
{
    public partial class NBA_SYS_Users
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserMetadata

    {

        [Display(Name = "First Name")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]

        public string fname { get; set; }



        [Display(Name = "Last Name")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]

        public string lname { get; set; }



        [Display(Name = "Email ID")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]

        [DataType(DataType.EmailAddress)]

        public string sys_emaild { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]

        [DataType(DataType.Password)]

        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]

        public string sys_password { get; set; }



        [Display(Name = "Confirm Password")]

        [DataType(DataType.Password)]

        [Compare("sys_password", ErrorMessage = "Confirm password and password do not match")]

        public string ConfirmPassword { get; set; }



    }



}