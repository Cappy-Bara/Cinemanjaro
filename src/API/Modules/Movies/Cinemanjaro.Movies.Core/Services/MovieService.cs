using Cinemanjaro.Movies.Core.DataAccessLayer.Storages;
using Cinemanjaro.Movies.Core.Entities;
using Cinemanjaro.Movies.Core.Exceptions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;
        public MovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<Movie> GetMovieDetails(ObjectId id)
        {
            var output = await _moviesRepository.Get(id);
            if (output == null)
                throw new MovieNotFoundException();

            return output;
        }
    }
}
