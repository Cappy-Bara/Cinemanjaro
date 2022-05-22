using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.DTOs
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
