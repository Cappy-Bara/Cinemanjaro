using Cinemanjaro.Users.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.DataAccessLayer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UsersRepository(IMongoClient mongoClient)
        {
            _usersCollection = mongoClient.GetDatabase("cinemanjaro_users")
                              .GetCollection<User>("users");
        }

        public async Task Create(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task Delete(string email)
        {
            var filter = GetMatchUserByEmailFilter(email);

            await _usersCollection.DeleteOneAsync(filter);
        }

        public async Task<User> Get(string email)
        {
            return await _usersCollection.Find(x => x.Email == email).FirstAsync();
        }

        public async Task Update(User user)
        {
            var filter = GetMatchUserByEmailFilter(user.Email);

            var updateBuilder = new UpdateDefinitionBuilder<User>();
            var update = updateBuilder.Set(x => x, user);

            await _usersCollection.UpdateOneAsync(filter, update);
        }

        private static FilterDefinition<User> GetMatchUserByEmailFilter(string email)
        {
            var filterBuilder = new FilterDefinitionBuilder<User>();
             return filterBuilder.Eq(x => x.Email, email);
        }
    }
}
