using MongoDB.Driver;

namespace Tomi.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IDataContext dataContext, string collectionName)
        {
            _collection = dataContext.GetCollection<T>(collectionName);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
