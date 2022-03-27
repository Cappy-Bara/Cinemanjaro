using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class NotFoundException : CinemanjaroException
    {
        public NotFoundException(string message) : base(message, 404)
        {
        }
    }
}
