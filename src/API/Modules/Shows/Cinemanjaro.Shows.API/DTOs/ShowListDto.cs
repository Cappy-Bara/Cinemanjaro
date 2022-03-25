using Cinemanjaro.Shows.Domain.Aggregates;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowListElementDto
    {
        public Guid ShowId { get; init; }
        public DateTime Date { get; init; }
        public string Title { get; init; }

        public ShowListElementDto(Show show)
        {
            ShowId = show.ShowId;
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
