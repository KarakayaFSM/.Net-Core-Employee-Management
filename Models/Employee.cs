using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
public class Employee
    {
        public int Id{ get; set; }   

        [Required]
        [MinLength(2,ErrorMessage = "Name should be at least 2 characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    
        [Required]
        public Dept? Department { get; set; }

        public string PhotoPath { get; set; }    
    }
