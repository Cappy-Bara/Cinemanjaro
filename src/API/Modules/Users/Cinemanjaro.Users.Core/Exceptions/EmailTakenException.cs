using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.Exceptions
{
    public class EmailTakenException : CinemanjaroException
    {
        public EmailTakenException() : base("This email is already taken.", 400)
        {
        }
    }
}
