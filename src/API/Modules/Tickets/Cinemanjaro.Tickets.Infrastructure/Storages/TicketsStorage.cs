using Cinemanjaro.Tickets.Application.Storages;
using Cinemanjaro.Tickets.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinemanjaro.Tickets.Infrastructure.Storages
{
    public class TicketsStorage : ITicketsStorage
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;

        public TicketsStorage(IMongoClient mongoClient)
        {
            _ticketsCollection = mongoClient.GetDatabase("cinemanjaro_tickets")
                                          .GetCollection<Ticket>("tickets");
        }

        public async Task<IEnumerable<Ticket>> GetAllNotBoughtTicketsFromSelectedTime(int periodInMinutes)
        {
            var time = DateTime.Now.AddMinutes(-periodInMinutes);

            return await _ticketsCollection.Find(x => x.Paid == false && x.ReservationTime < time).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllUserTickets(string email)
        {
            var filter = new BsonDocument("Email", email);
            return await _ticketsCollection.Find(filter).ToListAsync();
        }
    }
}
