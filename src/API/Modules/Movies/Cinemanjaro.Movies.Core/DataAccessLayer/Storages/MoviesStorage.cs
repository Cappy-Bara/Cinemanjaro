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

        public async Task<(List<MovieShortData> data,int amout)> Get(int page, int pageSize)
        {
            var output = await _moviesCollection.Find(x => true)
                             .Skip((page - 1) * pageSize)
                             .Limit(pageSize)
                             .Project(x => new MovieShortData
                             {
                                 Id = x.Id.ToString(),
                                 Title = x.Title,
                                 PhotoURL = x.PhotoURL
                             }).ToListAsync();

            var count = (int) await _moviesCollection.CountDocumentsAsync(x => true);

            return (output,count);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _moviesCollection.Find(x => true).ToListAsync();
        }
    }
}
