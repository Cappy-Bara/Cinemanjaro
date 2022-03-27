using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Shows.Queries
{
    public record GetShowsOfDate(DateOnly date) : IRequest<IEnumerable<Show>>;

    public class GetShowsOfDateHandler : IRequestHandler<GetShowsOfDate, IEnumerable<Show>>
    {
        private readonly IShowsStorage _showsStorage;

        public GetShowsOfDateHandler(IShowsStorage showsStorage)
        {
            _showsStorage = showsStorage;
        }

        public async Task<IEnumerable<Show>> Handle(GetShowsOfDate request, CancellationToken cancellationToken)
        {
            return await _showsStorage.GetShowsByDate(request.date);
        }
    }
}
