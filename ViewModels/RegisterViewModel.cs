using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Remote(controller:"Account",action:"IsEmailValid")]
        [ValidEmailDomain(allowedDomain: "gmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
          ErrorMessage = "The two fields doesn't match !")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }

    }
}
