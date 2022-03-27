using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinemanjaro.Shows.Application
{
    public static class Install
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Install).GetTypeInfo().Assembly);

            return services;
        }
    }
}
