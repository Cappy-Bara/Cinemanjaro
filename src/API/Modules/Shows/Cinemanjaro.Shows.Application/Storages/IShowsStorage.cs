using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Entities;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.Application.Storages
{
    public interface IShowsStorage
    {
        Task<IEnumerable<Show>> GetShowsByDate(DateOnly day);
        Task<IEnumerable<Show>> GetShows(IEnumerable<ObjectId> showIds);
    }
}
