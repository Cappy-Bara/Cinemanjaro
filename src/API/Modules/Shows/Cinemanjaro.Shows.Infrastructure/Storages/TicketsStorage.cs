using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Infrastructure.Storages
{
    public class TicketsStorage : ITicketsStorage
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public TicketsStorage(IMongoClient mongoClient)
        {
            _ticketsCollection = mongoClient.GetDatabase("cinemanjaro_shows")
                                          .GetCollection<Ticket>("tickets");
        }

        public async Task<IEnumerable<Ticket>> GetAllUserTickets(string email)
        {
            var filter = new BsonDocument("BuyerEmail", email);
            return await _ticketsCollection.Find(filter).ToListAsync();
        }
    }
}
