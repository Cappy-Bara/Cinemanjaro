using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using Cinemanjaro.Shows.Shared.Events.Shows;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.EventHandlers.Shows
{
    public class SeatBookedHandler : INotificationHandler<SeatsBooked>
    {
        private readonly ITicketsRepository _ticketsRepository;

        public SeatBookedHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public async Task Handle(SeatsBooked notification, CancellationToken cancellationToken)
        {
            var ticket = new Ticket()
            {
                Seats = notification.Seats.Select(x => new SeatPosition(x.Row,x.Number)),
                Email = notification.Email,
                ShowId = notification.ShowId,
                MovieTitle = notification.MovieTitle,
                Paid = false,
                ReservationTime = DateTime.Now,
                ShowDate = notification.ShowDate,
            };

            await _ticketsRepository.Create(ticket);
        }
    }
}
