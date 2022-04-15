using Cinemanjaro.Shows.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class SeatPositionDto
    {
        public int Row { get; set; }
        public int Number { get; set; }

        public SeatPositionDto()
        {

        }

        public SeatPositionDto(SeatPosition Position)
        {
            Row = Position.Row;
            Number = Position.Number;
        }
    }
}
