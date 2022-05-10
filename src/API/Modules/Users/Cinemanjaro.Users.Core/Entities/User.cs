using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core.Entities
{
    public class User
    {
        [BsonId]
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public void ApplyPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
    }
}
