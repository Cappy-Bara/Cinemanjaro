using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Shared.DTOs
{
    public class ShowFreedSeatsDto
    {
        public ObjectId ShowId { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; }
    }
}
