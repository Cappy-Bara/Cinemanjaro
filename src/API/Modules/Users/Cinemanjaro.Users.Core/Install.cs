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
            return services;
        }
    }
}
