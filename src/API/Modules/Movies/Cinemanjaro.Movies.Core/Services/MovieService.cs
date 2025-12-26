using Cinemanjaro.Movies.Core.DataAccessLayer.Storages;
using Cinemanjaro.Movies.Core.Entities;
using Cinemanjaro.Movies.Core.Exceptions;
using MongoDB.Bson;

namespace Cinemanjaro.Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMoviesStorage _moviesStorage;
        public MovieService(IMoviesRepository moviesRepository, IMoviesStorage moviesStorage)
        {
            _moviesRepository = moviesRepository;
            _moviesStorage = moviesStorage;
        }

        public async Task<Movie> GetMovieDetails(ObjectId id)
        {
            var output = await _moviesRepository.Get(id);
            if (output == null)
                throw new MovieNotFoundException();

            return output;
        }

        public async Task<(List<MovieShortData> data, int amount)> GetMovies(int page, int pageSize)
        {
            return await _moviesStorage.Get(page, pageSize);
        }
    }
}
