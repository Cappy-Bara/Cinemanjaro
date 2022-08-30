using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Jobs.Jobs.Tickets
{
    public interface IRemoveNotBoughtTickets : IJob {}

    public static class RemoveNotBoughtTicketsInstaller
    {
        public static IServiceCollectionQuartzConfigurator AddRemoveNotBoughtTicketsJob(this IServiceCollectionQuartzConfigurator q)
        {
            q.ScheduleJob<IRemoveNotBoughtTickets>(trigger =>
                trigger.WithSimpleSchedule(x => x.WithIntervalInMinutes(5).RepeatForever())
                       .WithDescription("Removing tickets which haven't been bought for 15 mins")
                       .StartNow());
            return q;
        }
    }
}
