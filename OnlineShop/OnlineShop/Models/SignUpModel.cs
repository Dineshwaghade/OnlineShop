using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class SignUpModel
    {
        public int User_Id { get; set; }
        [Required,Display(Name ="First Name")]
        public string First_Name { get; set; }
        [Required, Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        [Required, EmailAddress(ErrorMessage ="Invalid email address")]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Display(Name = "Confirm Password"),DataType(DataType.Password),Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}