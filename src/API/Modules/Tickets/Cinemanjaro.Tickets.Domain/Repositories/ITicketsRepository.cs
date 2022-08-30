using Cinemanjaro.Tickets.Domain.Entities;
using MongoDB.Bson;

namespace Cinemanjaro.Tickets.Domain.Repositories
{
    public interface ITicketsRepository
    {
        public Task<Ticket> Get(ObjectId Id);
        public Task Delete(ObjectId Id);
        public Task DeleteMany(IEnumerable<ObjectId> Id);
        public Task Update(Ticket ticket);
        public Task Create(Ticket ticket);
    }
}
