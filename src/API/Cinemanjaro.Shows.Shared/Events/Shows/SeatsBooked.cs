using Cinemanjaro.Shows.Shared.DTOs;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Shared.Events.Shows
{
    public class SeatsBooked : INotification
    {
        public ObjectId ShowId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public string Email { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; }
    }
}
