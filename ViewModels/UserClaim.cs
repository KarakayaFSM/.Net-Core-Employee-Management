using System.Security.Claims;

namespace EmployeeManagement.ViewModels
{
    public class UserClaim
    {
        public bool IsSelected { get; set; }
        public string ClaimType { get; set; }
    }
}
