using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Entities
{
    public class Seat
    {
        public SeatPosition Position { get; set; }
        public SeatStatus Status { get; set; }

        private Seat()
        {

        }
        public Seat(int row, int number)
        {
            Position = new SeatPosition(row, number);
        }

        public void BookSeat()
        {
            if (Status == SeatStatus.Occupied)
                throw new SeatOccupiedException(Position);
            
            Status = SeatStatus.Occupied;
        }
    }
}
