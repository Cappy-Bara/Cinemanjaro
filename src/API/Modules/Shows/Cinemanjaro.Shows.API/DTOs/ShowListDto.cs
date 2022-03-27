using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowListElementDto
    {
        public ObjectId Id { get; init; }
        public DateTime Date { get; init; }
        public string Title { get; init; }

        public ShowListElementDto(Show show)
        {
            Id = show.Id;
            Date = show.Date;
            Title = show.Title; 
        }
    }

    public class ShowListDto
    {
        public IEnumerable<ShowListElementDto> Shows { get; init; }

        public ShowListDto(IEnumerable<Show> shows)
        {
            Shows = shows.Select(show => new ShowListElementDto(show));
        }
    }
}
