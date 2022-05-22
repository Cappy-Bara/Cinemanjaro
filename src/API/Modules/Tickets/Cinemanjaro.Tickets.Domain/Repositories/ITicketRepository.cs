using Cinemanjaro.Tickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Domain.Repositories
{
    public interface ITicketRepository
    {
        public Task<Ticket> Get(int ticketId);
        public Task Create(Ticket ticket);
    }
}
