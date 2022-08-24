using Cinemanjaro.Tickets.Domain.Entities;
using Cinemanjaro.Tickets.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinemanjaro.Tickets.Infrastructure.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public TicketsRepository(IMongoClient mongoClient)
        {
            _ticketsCollection = mongoClient.GetDatabase("cinemanjaro_tickets")
                                          .GetCollection<Ticket>("tickets");
        }

        public async Task Create(Ticket ticket)
        {
            await _ticketsCollection.InsertOneAsync(ticket);
        }

        public async Task Delete(ObjectId Id)
        {
            var filter = new BsonDocument("_id", Id);
            await _ticketsCollection.DeleteOneAsync(filter);
        }

        public async Task<Ticket> Get(ObjectId Id)
        {
            var filter = new BsonDocument("_id", Id);
            return await _ticketsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(Ticket ticket)
        {
            var filter = new BsonDocument("_id", ticket.Id);
            await _ticketsCollection.ReplaceOneAsync(filter, ticket);
        }
    }
}
