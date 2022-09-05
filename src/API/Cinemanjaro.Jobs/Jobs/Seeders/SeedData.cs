using Cinemanjaro.Jobs.Events;
using MediatR;
using Quartz;

namespace Cinemanjaro.Jobs.Jobs.Seeders
{
    public class SeedData : IJob
    {
        private readonly IMediator mediator;
        public SeedData(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await mediator.Publish(new DataSeeded());
        }
    }

    public static class RemoveNotBoughtTicketsInstaller
    {
        public static IServiceCollectionQuartzConfigurator AddSeedingJob(this IServiceCollectionQuartzConfigurator q)
        {
            q.ScheduleJob<SeedData>(trigger =>
            trigger.WithSimpleSchedule(x => x.WithRepeatCount(0))
                        .WithDescription("Data seed on running")
                        .StartNow());

            q.ScheduleJob<SeedData>(trigger =>
                trigger.WithCronSchedule("0 1 0 ? * * *")
                        .WithDescription("Seed data")
                        .StartNow());

            return q;
        }
    }
}
