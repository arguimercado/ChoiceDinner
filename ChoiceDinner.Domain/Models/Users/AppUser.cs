using Microsoft.AspNetCore.Identity;

namespace ChoiceDinner.Domain.Models.Users
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; }  = string.Empty;
        public string LastName { get; set; }  = string.Empty;
    }
}