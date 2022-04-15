using Cinemanjaro.Movies.Core.DataAccessLayer.Storages;
using Cinemanjaro.Movies.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Movies.Core
{
    public static class Install
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesStorage, MoviesStorage>();

            return services;
        }
    }
}