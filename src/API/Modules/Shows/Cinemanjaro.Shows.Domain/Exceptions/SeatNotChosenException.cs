using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class SeatNotChosenException : CinemanjaroException
    {
        public SeatNotChosenException() : base("You have to choose at least one seat!", 400)
        {
        }
    }
}
