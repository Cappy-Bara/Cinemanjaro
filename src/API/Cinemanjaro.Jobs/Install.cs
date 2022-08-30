using Cinemanjaro.Jobs.Jobs.Tickets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Cinemanjaro.Jobs
{
    public static class Install
    {
        public static IServiceCollection AddJobs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                q.AddRemoveNotBoughtTicketsJob();
            });

            services.AddQuartzHostedService();

            return services;
        }

        public static IApplicationBuilder UseJobs(this IApplicationBuilder app)
        {
            return app;
        }
    }
}