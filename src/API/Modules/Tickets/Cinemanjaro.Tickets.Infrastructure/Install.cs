using Cinemanjaro.Tickets.Application.Storages;
using Cinemanjaro.Tickets.Domain.Repositories;
using Cinemanjaro.Tickets.Infrastructure.Repositories;
using Cinemanjaro.Tickets.Infrastructure.Storages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Tickets.Infrastructure
{
    public static class Install
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<ITicketsRepository, TicketsRepository>();

            services.AddScoped<ITicketsStorage, TicketsStorage>();

            return services;
        }
    }
}
