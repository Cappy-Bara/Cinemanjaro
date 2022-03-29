using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class ShowInPastException : CinemanjaroException
    {
        public ShowInPastException() : base("This show has already taken place.",400)
        {
        }
    }
}
