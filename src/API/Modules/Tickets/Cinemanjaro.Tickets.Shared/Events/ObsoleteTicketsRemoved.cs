using Cinemanjaro.Tickets.Shared.DTOs;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Shared.Events
{
    public class ObsoleteTicketsRemoved : INotification
    {
        public IEnumerable<ShowFreedSeatsDto> ShowsWithFreedSeats { get; set; }
    }
}
