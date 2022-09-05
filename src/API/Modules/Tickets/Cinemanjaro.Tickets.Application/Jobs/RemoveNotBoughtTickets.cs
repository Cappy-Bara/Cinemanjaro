using Cinemanjaro.Jobs.Jobs.Tickets;
using Cinemanjaro.Tickets.Application.Storages;
using Cinemanjaro.Tickets.Domain.Repositories;
using Cinemanjaro.Tickets.Shared.DTOs;
using Cinemanjaro.Tickets.Shared.Events;
using MediatR;
using Quartz;

namespace Cinemanjaro.Tickets.Application.Jobs
{
    public class RemoveNotBoughtTickets : IRemoveNotBoughtTickets
    {
        private readonly ITicketsRepository ticketsRepository;
        private readonly ITicketsStorage ticketsStorage;
        private readonly IMediator mediator;

        public RemoveNotBoughtTickets(ITicketsRepository ticketsRepository, ITicketsStorage ticketsStorage, IMediator mediator)
        {
            this.ticketsRepository = ticketsRepository;
            this.ticketsStorage = ticketsStorage;
            this.mediator = mediator;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var tickets = await ticketsStorage.GetAllNotBoughtTicketsFromSelectedTime(15);

            if (!tickets.Any())
                return;

            await ticketsRepository.DeleteMany(tickets.Select(x => x.Id));

            var notification = new ObsoleteTicketsRemoved()
            {
                ShowsWithFreedSeats = tickets.GroupBy(x => x.ShowId, z => new ShowFreedSeatsDto
                {
                    Seats = z.Seats.Select(x => new SeatDto(x.Row, x.Number)),
                    ShowId = z.ShowId
                }).SelectMany(x => x)
            };
        
            await mediator.Publish(notification);
        }
    }
}
