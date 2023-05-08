using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace Tomi.Domain.Entities
{
    public class User :  MongoIdentityUser 
    {
		public string UserId { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }


	}
}
