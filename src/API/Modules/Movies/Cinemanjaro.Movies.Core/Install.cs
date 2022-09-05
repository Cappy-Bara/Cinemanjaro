using Cinemanjaro.Movies.Core.DataAccessLayer.Storages;
using Cinemanjaro.Movies.Core.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinemanjaro.Movies.Core
{
    public static class Install
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Install).GetTypeInfo().Assembly);

            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesStorage, MoviesStorage>();

            return services;
        }
    }
}