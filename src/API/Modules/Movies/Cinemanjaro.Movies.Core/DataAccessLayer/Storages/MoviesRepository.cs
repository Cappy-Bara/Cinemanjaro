using Cinemanjaro.Movies.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.DataAccessLayer.Storages
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;

        public MoviesRepository(IMongoClient mongoClient)
        {
            _moviesCollection = mongoClient.GetDatabase("cinemanjaro_movies")
                                          .GetCollection<Movie>("movies");
        }

        public async Task<Movie> Get(ObjectId Id)
        {
            return await _moviesCollection.Find(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task InsertMany(IEnumerable<Movie> movies)
        {
            await _moviesCollection.InsertManyAsync(movies);
        }
    }
}
