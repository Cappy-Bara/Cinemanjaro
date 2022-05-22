using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Entities;
using MediatR;

namespace Cinemanjaro.Shows.Application.Tickets.Queries
{
    public record GetAllUserTickets(string userEmail) : IRequest<IEnumerable<Ticket>>;

    public class GetAllUserTicketsHandler : IRequestHandler<GetAllUserTickets, IEnumerable<Ticket>>
    {
        private readonly ITicketsStorage ticketsStorage;
        public GetAllUserTicketsHandler(ITicketsStorage ticketsStorage)
        {
            this.ticketsStorage = ticketsStorage;
        }

        public async Task<IEnumerable<Ticket>> Handle(GetAllUserTickets request, CancellationToken cancellationToken)
        {
            return(await ticketsStorage.GetAllUserTickets(request.userEmail));
        }
    }
}
 