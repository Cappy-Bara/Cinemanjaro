using Cinemanjaro.Movies.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Movies.API
{
    public static class Install
    {
        public static IServiceCollection AddMoviesModule(this IServiceCollection services)
        {
            services.AddCoreLayer();

            return services;
        }

        public static IApplicationBuilder UseMoviesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}