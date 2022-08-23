using Cinemanjaro.Tickets.Domain.Entities;

namespace Cinemanjaro.Tickets.API.DTOs
{
    public class TicketsDto
    {
        public IEnumerable<TicketDto> Tickets { get; set; }

        public TicketsDto()
        {
        }

        public TicketsDto(IEnumerable<Ticket> tickets)
        {
            Tickets = tickets.Select(ticket => new TicketDto(ticket));
        }
    }
}
