using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {

        [Required]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        [Required]
        public Dept? Department { get; set; }


        public IFormFile Photo { get; set; }
    }
}
