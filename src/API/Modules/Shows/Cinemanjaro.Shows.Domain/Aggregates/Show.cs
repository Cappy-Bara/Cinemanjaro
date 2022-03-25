using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Aggregates
{
    public class Show
    {
        public Guid ShowId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<Seat> Seats { get; set; }

        public void BookSeats(IEnumerable<SeatPosition> seatPositions)
        {
            foreach (SeatPosition position in seatPositions)
            {
                var seat = Seats.FirstOrDefault(x => x.Position == position);
                if (seat == null)
                    throw new SeatDoesNotExistException(position);

                seat.BookSeat();
            }
        }
    }
}
