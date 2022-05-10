﻿using Cinemanjaro.Tickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Application.Storages
{
    public interface ITicketsStorage
    {
        public Task<IEnumerable<Ticket>> GetUserTickets(string email);
    }
}
