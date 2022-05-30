using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Infrastructure.Repositories;
using Cinemanjaro.Shows.Infrastructure.Storages;
using Cinemanjaro.Shows.Infrastructure.EmailSending;
using Microsoft.Extensions.DependencyInjection;
using Cinemanjaro.Shows.Application.EmailSending;

namespace Cinemanjaro.Shows.Infrastructure
{
    public static class Install
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IShowsRepository,ShowsRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();

            services.AddScoped<IShowsStorage,ShowsStorage>();
            services.AddScoped<ITicketsStorage,TicketsStorage>();
            services.AddScoped<IMoviesStorage,MoviesStorage>();
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}
