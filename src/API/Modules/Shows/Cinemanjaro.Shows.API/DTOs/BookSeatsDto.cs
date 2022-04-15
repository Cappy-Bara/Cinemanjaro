namespace Cinemanjaro.Shows.API.DTOs
{
    public class BookSeatsDto
    {
        public string Email { get; set; }
        public List<SeatPositionDto> SeatPositions { get; set; }
    }
}
