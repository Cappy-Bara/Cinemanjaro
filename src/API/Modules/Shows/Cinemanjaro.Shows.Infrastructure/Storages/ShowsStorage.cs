using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Cinemanjaro.Shows.Infrastructure.Storages
{
    public class ShowsStorage : IShowsStorage
    {

        private readonly IMongoCollection<Show> _showsCollection;

        public ShowsStorage(IMongoClient mongoClient)
        {
            _showsCollection = mongoClient.GetDatabase("cinemanjaro_shows")
                                          .GetCollection<Show>("shows");
        }

        public async Task<IEnumerable<Show>> GetShows(IEnumerable<ObjectId> showIds)
        {
            return await _showsCollection.Find(x => showIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Show>> GetShowsByDate(DateOnly day)
        {
            var timeBegin = new TimeOnly(00,00,00,00);

            var dateBegin = day.ToDateTime(timeBegin).ToUniversalTime();
            var dateEnds = day.ToDateTime(timeBegin).AddDays(1).ToUniversalTime();

            var builder = Builders<Show>.Filter;
            
            var filter1 = builder.Gte(x => x.Date, dateBegin);
            var filter2 = builder.Lte(x => x.Date, dateEnds);
            
            var outputFilter = builder.And(filter1, filter2);

            var cursor = await _showsCollection.FindAsync(outputFilter);
            
            return await cursor.ToListAsync();
        }
    }
}
