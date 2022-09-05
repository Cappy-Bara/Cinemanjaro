using Quartz;

namespace Cinemanjaro.Jobs.Jobs.Tickets
{
    public interface IRemoveNotBoughtTickets : IJob {}

    public static class RemoveNotBoughtTicketsInstaller
    {
        public static IServiceCollectionQuartzConfigurator AddRemoveNotBoughtTicketsJob(this IServiceCollectionQuartzConfigurator q)
        {
            q.ScheduleJob<IRemoveNotBoughtTickets>(trigger =>
                trigger.WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever())
                       .WithDescription("Removing tickets which haven't been bought for 15 mins")
                       .StartNow());
            return q;
        }
    }
}
