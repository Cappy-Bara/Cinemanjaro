using Cinemanjaro.Tickets.Domain.ValueObjects;

namespace Cinemanjaro.Tickets.API.DTOs
{
    public class SeatPositionDto
    {
        public int Row { get; set; }
        public int Number { get; set; }

        public SeatPositionDto()
        {

        }

        public SeatPositionDto(SeatPosition Position)
        {
            Row = Position.Row;
            Number = Position.Number;
        }
    }
}
