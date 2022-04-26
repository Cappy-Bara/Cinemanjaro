using Cinemanjaro.Users.Core.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.DataAccessLayer.Repositories
{
    public interface IUsersRepository
    {
        public Task Create(User user);
        public Task<User> Get(string email);
        public Task Update(User user);
        public Task Delete(string email);
    }
}
