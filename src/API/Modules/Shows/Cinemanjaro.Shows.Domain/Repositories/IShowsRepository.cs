using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Repositories
{
    public interface IShowsRepository
    {
        public Task<Show> Get(ObjectId showId);
        public Task Delete(ObjectId showId);
        public Task Update(Show show);
        public Task Create(Show show);
    }
}
