using MongoDB.Driver;

namespace Tomi.Infrastructure.Contexts
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(String collectionName);
    }
}
