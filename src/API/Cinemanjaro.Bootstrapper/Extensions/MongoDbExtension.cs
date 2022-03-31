using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
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
            var mongoConnectionUrl = new MongoUrl(config.GetConnectionString("MongoDb"));
#if DEBUG
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
            mongoClientSettings.ClusterConfigurator = cb => {
                cb.Subscribe<CommandStartedEvent>(e => {
                    Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
                });
            };
            var client = new MongoClient(mongoClientSettings);
#else
            var client = new MongoClient(mongoConnectionUrl);
#endif
            services.AddScoped<IMongoClient, MongoClient>(serviceProvider =>
                client);
            return services;
        }
    }
}
