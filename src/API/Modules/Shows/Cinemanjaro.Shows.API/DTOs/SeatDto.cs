using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.ValueObjects;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class SeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatStatus Status { get; set; }

        public SeatDto(Seat seat)
        {
            Row = seat.Position.Row;
            Number = seat.Position.Number;
            Status = seat.Status;
        }
    }
}
