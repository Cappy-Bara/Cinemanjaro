using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinemanjaro.Shows.Infrastructure.Repositories
{
    public class ShowsRepository : IShowsRepository
    {
        private readonly IMongoCollection<Show> _showsCollection;

        public ShowsRepository(IMongoClient mongoClient)
        {
            _showsCollection = mongoClient.GetDatabase("cinemanjaro_shows")
                                          .GetCollection<Show>("shows");
        }

        public async Task Delete(ObjectId showId)
        {
            var filter = new BsonDocument("_id",showId);
            await _showsCollection.DeleteOneAsync(filter);
        }

        public async Task<Show> Get(ObjectId showId)
        {
            var filter = new BsonDocument("_id", showId);
            return await _showsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Create(Show show)
        {
            await _showsCollection.InsertOneAsync(show);
        }

        public async Task Update(Show show)
        {
            var filter = new BsonDocument("_id", show.Id);
            await _showsCollection.ReplaceOneAsync(filter,show);
        }
    }
}
