namespace Cinemanjaro.Shows.API.DTOs
{
    public class BookSeatsDto
    {
        public string Email { get; set; }
        public IEnumerable<SeatPositionDto> SeatPositions { get; set; }
    }
}
