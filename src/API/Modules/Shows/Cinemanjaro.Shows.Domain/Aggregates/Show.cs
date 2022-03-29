using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.Domain.Aggregates
{
    public class Show
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Seat> Seats { get; set; }

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
