using Cinemanjaro.Jobs.Jobs.Tickets;
using Cinemanjaro.Tickets.Application.Jobs;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinemanjaro.Tickets.Application
{
    public static class Install
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Install).GetTypeInfo().Assembly);

            services.AddScoped<IRemoveNotBoughtTickets,RemoveNotBoughtTickets>();

            return services;
        }
    }
}
