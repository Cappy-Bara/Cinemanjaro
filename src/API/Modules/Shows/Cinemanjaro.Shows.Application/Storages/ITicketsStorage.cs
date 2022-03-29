using Cinemanjaro.Shows.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Storages
{
    public interface ITicketsStorage
    {
        public Task<IEnumerable<Ticket>> GetAllUserTickets(string email);
    }
}
