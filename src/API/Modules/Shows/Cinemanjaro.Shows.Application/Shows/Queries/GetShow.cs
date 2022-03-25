using MediatR;
using Cinemanjaro.Shows.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemanjaro.Shows.Domain.Repositories;

namespace Cinemanjaro.Shows.Application.Shows.Queries
{
    public record GetShow(Guid ShowId) : IRequest<Show>;

    public class GetShowHandler : IRequestHandler<GetShow, Show>
    {
        private readonly IShowsRepository _showsRepository;
        public GetShowHandler(IShowsRepository showsRepository)
        {
            _showsRepository = showsRepository;
        }

        public async Task<Show> Handle(GetShow request, CancellationToken cancellationToken)
        {
            return await _showsRepository.Get(request.ShowId);
        }
    }
}
