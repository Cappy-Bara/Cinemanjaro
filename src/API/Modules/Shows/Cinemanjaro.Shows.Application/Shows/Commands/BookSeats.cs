using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Shows.Commands
{
    public record BookSeats(IEnumerable<SeatPosition> seats,Guid showId) : IRequest<Unit>;

    public class BookSeatsHandler : IRequestHandler<BookSeats, Unit>
    {
        private readonly IShowsRepository _showsRepo;
        public BookSeatsHandler(IShowsRepository showsRepo)
        {
            _showsRepo = showsRepo;
        }


        public async Task<Unit> Handle(BookSeats request, CancellationToken cancellationToken)
        {
            if(request.seats.Distinct().Count() != request.seats.Count())
               throw new SeatReservedMultipleTimesException();

            var show = await _showsRepo.Get(request.showId);

            show.BookSeats(request.seats);

            return Unit.Value;
        }
    }
}
