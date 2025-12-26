using Cinemanjaro.Movies.Core.Entities;
using MongoDB.Bson;

namespace Cinemanjaro.Movies.Core.Services;

public interface IMovieService
{
    public Task<Movie> GetMovieDetails(ObjectId id);

    public Task<(List<MovieShortData> data, int amount)> GetMovies(int page, int pageSize);
}
