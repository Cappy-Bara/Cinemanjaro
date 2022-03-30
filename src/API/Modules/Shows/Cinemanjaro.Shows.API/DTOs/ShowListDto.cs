using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowListDto
    {
        public IEnumerable<ShowDto> Shows { get; init; }

        public ShowListDto(IEnumerable<Show> shows)
        {
            Shows = shows.Select(show => new ShowDto(show));
        }
    }
}
