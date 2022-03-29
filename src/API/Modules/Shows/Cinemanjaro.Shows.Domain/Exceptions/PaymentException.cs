using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class PaymentException : CinemanjaroException
    {
        public PaymentException(string message) : base(message, 400)
        {
        }
    }
}
