using Microsoft.AspNetCore.Identity;

namespace Tomi.Domain.Entities
{
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
