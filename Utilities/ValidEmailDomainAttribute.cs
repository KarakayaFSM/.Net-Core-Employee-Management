using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomain(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
            ErrorMessage = "Email domain must be gmail.com";
        }
        
        public override bool IsValid(object value)
        {
            //@ işaretinden sonraki kısmı almak için dizinin 1. elem. alınır
            return allowedDomain.ToUpper()
            == value.ToString().Split("@")[1].ToUpper();
        }
    }
}
