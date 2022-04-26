using Cinemanjaro.Users.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Users.API
{
    public static class Install
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            services.AddCoreLayer();

            return services;
        }

        public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
