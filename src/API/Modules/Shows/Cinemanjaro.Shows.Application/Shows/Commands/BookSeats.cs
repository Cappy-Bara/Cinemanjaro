using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using Cinemanjaro.Shows.Shared.DTOs;
using Cinemanjaro.Shows.Shared.Events.Shows;
using MediatR;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.Application.Shows.Commands
{
    public record BookSeats(IEnumerable<SeatPosition> Seats,string Email,ObjectId ShowId) : IRequest<Unit>;

    public class BookSeatsHandler : IRequestHandler<BookSeats, Unit>
    {
        private readonly IShowsRepository _showsRepo;
        private readonly IMediator _mediator;
        public BookSeatsHandler(IShowsRepository showsRepo, IMediator mediator)
        {
            _showsRepo = showsRepo;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(BookSeats request, CancellationToken cancellationToken)
        {
            if(request.Seats.Distinct().Count() != request.Seats.Count())
               throw new SeatReservedMultipleTimesException();

            if (request.Seats.Count() == 0)
                throw new SeatNotChosenException();

            var show = await _showsRepo.Get(request.ShowId);
            if (show is null)
                throw new NotFoundException("This show does not exist.");

            if(show.Date < DateTime.Now.ToUniversalTime())
                throw new ShowInPastException();

            show.BookSeats(request.Seats);

            await _showsRepo.Update(show);

            var @event = new SeatsBooked()
            {
                Email = request.Email,
                MovieTitle = show.Title,
                ShowDate = show.Date,
                ShowId = request.ShowId,
                Seats = request.Seats.Select(x => new SeatDto(x.Row,x.Number))
            };

            await _mediator.Publish(@event);

            return Unit.Value;
        }
    }
}
