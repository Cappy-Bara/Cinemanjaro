using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.DTOs
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
