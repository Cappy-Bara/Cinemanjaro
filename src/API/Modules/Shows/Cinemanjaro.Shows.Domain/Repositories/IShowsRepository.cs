using Cinemanjaro.Shows.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Repositories
{
    public interface IShowsRepository
    {
        public Task<Show> Get(Guid ShowId);
        public Task<Show> Delete(Guid ShowId);
        public Task<Show> Update(Show show);
        public Task<Show> Post(Show show);
    }
}
