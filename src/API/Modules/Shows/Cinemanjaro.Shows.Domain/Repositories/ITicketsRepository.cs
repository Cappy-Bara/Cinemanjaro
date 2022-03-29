using Cinemanjaro.Shows.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Repositories
{
    public interface ITicketsRepository
    {
        public Task<Ticket> Get(ObjectId Id);
        public Task Delete(ObjectId Id);
        public Task Update(Ticket ticket);
        public Task Create(Ticket ticket);
    }
}
