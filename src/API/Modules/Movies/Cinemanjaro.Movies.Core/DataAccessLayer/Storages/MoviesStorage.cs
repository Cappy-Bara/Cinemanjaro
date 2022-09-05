using Cinemanjaro.Movies.Core.Entities;
using MongoDB.Driver;

namespace Cinemanjaro.Movies.Core.DataAccessLayer.Storages
{
    public class MoviesStorage : IMoviesStorage
    {
        private readonly IMongoCollection<Movie> _moviesCollection;

        public MoviesStorage(IMongoClient mongoClient)
        {
            _moviesCollection = mongoClient.GetDatabase("cinemanjaro_movies")
                                          .GetCollection<Movie>("movies");
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _moviesCollection.Find(x => true).ToListAsync();
        }
    }
}
