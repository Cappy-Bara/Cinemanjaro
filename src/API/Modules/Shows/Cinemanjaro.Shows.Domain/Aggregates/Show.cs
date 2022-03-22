using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Aggregates
{
    internal class Show
    {
        public Guid ShowId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
