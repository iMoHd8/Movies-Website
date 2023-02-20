using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }


        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required]
        [Compare(nameof(password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
