using Cinemanjaro.Shows.Application.EmailSending;
using Cinemanjaro.Shows.Shared.Events.Shows;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.EventHandlers.Shows
{
    public class SendBookedTickets : INotificationHandler<SeatsBooked>
    {
        private readonly IEmailSender _emailSender;

        public SendBookedTickets(IEmailSender ticketsRepository)
        {
            _emailSender = ticketsRepository;
        }

        public async Task Handle(SeatsBooked notification, CancellationToken cancellationToken)
        {
            var seats = notification.Seats.Select(x => $"Row: {x.Row} Number: {x.Number}");
            var seatsString = string.Join('\n', seats);

            var body = 
                @$"Hi!
                This is your ticket for {notification.MovieTitle}
                Date: {notification.ShowDate}
                Seats:
                " + seatsString;

            await _emailSender.SendEmail(notification.Email,"Tickets for show",body);
        }
    }
}
