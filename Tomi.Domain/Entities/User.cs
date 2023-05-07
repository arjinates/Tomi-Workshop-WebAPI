using AspNetCore.Identity.MongoDbCore.Models;


namespace Tomi.Domain.Entities
{
    public class User : MongoIdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
    }
}
