using Cinemanjaro.Common.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class SeatDoesNotExistException : CinemanjaroException
    {
        public SeatDoesNotExistException(SeatPosition seat) : base($"Seat in row {seat.Row} with number {seat.Number} does not exist.", 400)
        {
        }
    }
}
