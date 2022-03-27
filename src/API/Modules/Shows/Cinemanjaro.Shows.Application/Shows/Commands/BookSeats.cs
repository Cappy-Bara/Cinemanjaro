using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Shows.Commands
{
    public record BookSeats(IEnumerable<SeatPosition> Seats,string Email,ObjectId ShowId) : IRequest<Unit>;

    public class BookSeatsHandler : IRequestHandler<BookSeats, Unit>
    {
        private readonly IShowsRepository _showsRepo;
        public BookSeatsHandler(IShowsRepository showsRepo)
        {
            _showsRepo = showsRepo;
        }


        public async Task<Unit> Handle(BookSeats request, CancellationToken cancellationToken)
        {
            if(request.Seats.Distinct().Count() != request.Seats.Count())
               throw new SeatReservedMultipleTimesException();

            var show = await _showsRepo.Get(request.ShowId);
            if (show is null)
                throw new NotFoundException("This show does not exist.");

            show.BookSeats(request.Seats);

            await _showsRepo.Update(show);

            return Unit.Value;
        }
    }
}
