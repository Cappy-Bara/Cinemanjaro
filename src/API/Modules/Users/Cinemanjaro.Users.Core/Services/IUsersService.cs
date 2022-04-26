using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.Services
{
    public interface IUsersService
    {
        public Task RegisterUser(string email, string password);
    }
}
