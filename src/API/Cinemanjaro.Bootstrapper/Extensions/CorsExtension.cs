using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Bootstrapper.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCinemanjaroCors(this IServiceCollection services)
        {

#if DEBUG
            Console.WriteLine("All origins cors policy added.");
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    );
            });
#endif

            return services;
        }
    }
}
