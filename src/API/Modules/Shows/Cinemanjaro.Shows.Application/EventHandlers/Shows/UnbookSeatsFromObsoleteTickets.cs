using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using Cinemanjaro.Tickets.Shared.Events;
using MediatR;
using System.Runtime.CompilerServices;

namespace Cinemanjaro.Shows.Application.EventHandlers.Shows
{
    public class UnbookSeatsFromObsoleteTickets : INotificationHandler<ObsoleteTicketsRemoved>
    {
        private readonly IShowsRepository showsRepository;
        private readonly IShowsStorage showsStorage;

        public UnbookSeatsFromObsoleteTickets(IShowsRepository showsRepository, IShowsStorage showsStorage)
        {
            this.showsRepository = showsRepository;
            this.showsStorage = showsStorage;
        }

        public async Task Handle(ObsoleteTicketsRemoved notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("SEATS FREEING IN PROGRESS...");

            var shows = await showsStorage.GetShows(notification.ShowsWithFreedSeats.Select(x => x.ShowId));

            foreach (var showWithFreedSeats in notification.ShowsWithFreedSeats)
            {
                var show = shows.First(s => s.Id == showWithFreedSeats.ShowId);

                var seatsToFree = show.Seats.Where(s => showWithFreedSeats.Seats.Select(swfs => new SeatPosition(swfs.Row, swfs.Number)).ToList().Contains(s.Position));
                seatsToFree.ToList().ForEach(stf => stf.Status = SeatStatus.Free);
                
                await showsRepository.Update(show);
            }

            Console.WriteLine("SEATS HAS BEEN FREED");
        }
    }
}
