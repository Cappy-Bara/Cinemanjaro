using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Infrastructure.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public TicketsRepository(IMongoClient mongoClient)
        {
            _ticketsCollection = mongoClient.GetDatabase("cinemanjaro_shows")
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
