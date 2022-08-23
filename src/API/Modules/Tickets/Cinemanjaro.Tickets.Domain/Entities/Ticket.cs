using Cinemanjaro.Tickets.Domain.Exceptions;
using Cinemanjaro.Tickets.Domain.ValueObjects;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Domain.Entities
{
    public class Ticket
    {
        public ObjectId Id { get; set; }
        public ObjectId ShowId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public string Email { get; set; }
        public DateTime ReservationTime { get; set; } = DateTime.Now;
        public bool Paid { get; set; }
        public IEnumerable<SeatPosition> Seats { get; set; }

        public void PayForTicket()
        {
            if (Paid)
                throw new PaymentException("This ticket has already been paid.");

            Paid = true;
        }
    }
}
