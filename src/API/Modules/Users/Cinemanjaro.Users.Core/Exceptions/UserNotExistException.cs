using Cinemanjaro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.Exceptions
{
    public class UserNotExistException : CinemanjaroException
    {
        public UserNotExistException() : base("User with this email does not exist.", 404)
        {
        }
    }
}
