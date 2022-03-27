using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Infrastructure.Repositories;
using Cinemanjaro.Shows.Infrastructure.Storages;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Shows.Infrastructure
{
    public static class Install
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IShowsRepository,ShowsRepository>();
            services.AddScoped<IShowsStorage,ShowsStorage>();

            return services;
        }
    }
}
