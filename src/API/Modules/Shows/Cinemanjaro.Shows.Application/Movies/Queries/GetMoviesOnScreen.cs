using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Entities;
using MediatR;

namespace Cinemanjaro.Shows.Application.Movies.Queries
{
    public record GetMoviesOnScreen : IRequest<IEnumerable<Movie>>;

    public class GetMoviesOnScreenHandler : IRequestHandler<GetMoviesOnScreen, IEnumerable<Movie>>
    {
        private readonly IMoviesStorage _moviesStorage;

        public GetMoviesOnScreenHandler(IMoviesStorage moviesStorage)
        {
            _moviesStorage = moviesStorage;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesOnScreen request, CancellationToken cancellationToken)
        {
            return await _moviesStorage.GetMoviesOnScreen();
        }
    }
}
