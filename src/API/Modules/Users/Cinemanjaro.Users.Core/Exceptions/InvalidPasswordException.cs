using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.Exceptions
{
    public class InvalidPasswordException : CinemanjaroException
    {
        public InvalidPasswordException() : base("Password you've provided is invalid.", 400)
        {
        }
    }
}
