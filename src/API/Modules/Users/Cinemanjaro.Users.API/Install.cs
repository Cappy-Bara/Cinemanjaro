using Cinemanjaro.Users.API.Extensions;
using Cinemanjaro.Users.Core;
using Cinemanjaro.Users.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemanjaro.Users.API
{
    public static class Install
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddCustomAuthentication(configuration);

            services.AddCoreLayer();

            return services;
        }

        public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
