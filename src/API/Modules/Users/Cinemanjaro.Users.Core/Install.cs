using Cinemanjaro.Users.Core.DataAccessLayer.Repositories;
using Cinemanjaro.Users.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Users.Core
{
    public static class Install
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddScoped<IUsersService, UsersService>();

            return services;
        }
    }
}
