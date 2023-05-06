using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Tomi.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; } 

    }
}
