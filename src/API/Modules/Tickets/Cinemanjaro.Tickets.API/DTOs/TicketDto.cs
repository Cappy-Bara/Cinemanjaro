using Cinemanjaro.Tickets.Domain.Entities;

namespace Cinemanjaro.Tickets.API.DTOs
{
    public class TicketDto
    {
        public string Id { get; set; }
        public string ShowId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public IEnumerable<SeatPositionDto> Seats { get; set; }

        public TicketDto()
        {

        }

        public TicketDto(Ticket ticket)
        {
            Id = ticket.Id.ToString();
            ShowId = ticket.ShowId.ToString();
            MovieTitle = ticket.MovieTitle;
            ShowDate = ticket.ShowDate;
            Seats = ticket.Seats.Select(x => new SeatPositionDto(x));
        }
    }
}
