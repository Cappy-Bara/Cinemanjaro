using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Entities;

namespace Cinemanjaro.Shows.Application.Storages
{
    public interface IShowsStorage
    {
        Task<IEnumerable<Show>> GetShowsByDate(DateOnly day);
    }
}
