using Cinemanjaro.Tickets.Application;
using Cinemanjaro.Tickets.Domain;
using Cinemanjaro.Tickets.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Tickets.API
{
    public static class Install
    {
        public static IServiceCollection AddTicketsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer(configuration);
            services.AddInfrastructureLayer();

            return services;
        }

        public static IApplicationBuilder UseTicketsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
