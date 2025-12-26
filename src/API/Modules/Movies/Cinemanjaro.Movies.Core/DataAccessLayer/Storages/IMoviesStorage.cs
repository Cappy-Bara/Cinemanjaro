using Cinemanjaro.Movies.Core.Entities;

namespace Cinemanjaro.Movies.Core.DataAccessLayer.Storages;

public interface IMoviesStorage
{
    public Task<IEnumerable<Movie>> GetAll();
    public Task<(List<MovieShortData> data, int amout)> Get(int page, int pageSize);
}
