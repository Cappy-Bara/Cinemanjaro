using Cinemanjaro.Shows.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Storage
{
    public interface IShowsStorage
    {
        Task<IEnumerable<Show>> GetShowsByDate(DateOnly day);
    }
}
