using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Bootstrapper.Extensions
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IMongoClient, MongoClient>(serviceProvider =>
                new MongoClient(config.GetConnectionString("MongoDb")));

            return services;
        }
    }
}
