using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class SeatReservedMultipleTimesException : CinemanjaroException
    {
        public SeatReservedMultipleTimesException() : base("You cannot book same seat multiple times.", 400)
        {
        }
    }
}
