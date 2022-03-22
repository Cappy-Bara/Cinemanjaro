using Cinemanjaro.Shows.Application;
using Cinemanjaro.Shows.Domain;
using Cinemanjaro.Shows.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace Cinemanjaro.Shows.API
{
    public static class Install
    {
        public static IServiceCollection AddShowsModule(this IServiceCollection services)
        {
            services.AddDomainLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();

            return services;
        }

        public static IApplicationBuilder UseShowsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
