using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Repositories;

namespace Cinemanjaro.Tickets.Infrastructure.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        public Task Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task Delete(global::MongoDB.Bson.ObjectId Id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> Get(global::MongoDB.Bson.ObjectId Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
