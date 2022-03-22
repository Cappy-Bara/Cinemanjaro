using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Common.Exceptions
{
    public class CinemanjaroException : Exception
    {
        public int StatusCode { get; set; }

        public CinemanjaroException(string message, int code) : base(message)
        {
            StatusCode = code;
        }
    }
}
