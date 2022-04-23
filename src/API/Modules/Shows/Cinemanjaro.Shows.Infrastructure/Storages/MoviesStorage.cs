using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Entities;
using MongoDB.Driver;

namespace Cinemanjaro.Shows.Infrastructure.Storages
{
    public class MoviesStorage : IMoviesStorage
    {
        private readonly IMongoCollection<Show> _showsCollection;

        public MoviesStorage(IMongoClient mongoClient)
        {
            _showsCollection = mongoClient.GetDatabase("cinemanjaro_shows")
                                          .GetCollection<Show>("shows");
        }

        public async Task<IEnumerable<Movie>> GetMoviesOnScreen()
        {
            var filterBuilder = new FilterDefinitionBuilder<Show>();
            var dateFilter = filterBuilder.Gte(x => x.Date, DateTime.Now);

            var output = _showsCollection.Aggregate()
                .Match(dateFilter)
                .Group(x => 
                x.Id,
                y => new Movie
                {
                    MovieId = y.Key,
                    IconURL = y.First().IconURL,
                    Genres = y.First().Genres,
                    Title = y.First().Title,
                });

            return await output.ToListAsync();
        }
    }
}
