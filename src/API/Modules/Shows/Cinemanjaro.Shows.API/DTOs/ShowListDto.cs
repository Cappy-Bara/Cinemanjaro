using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowListElementDto
    {
        public string Id { get; init; }
        public DateTime Date { get; init; }
        public string Title { get; init; }
        public string IconURL { get; set; }
        public string MovieId { get; set; }
        public int LengthMins { get; set; }
        public IEnumerable<string> Genres { get; set; }


        public ShowListElementDto(Show show)
        {
            Id = show.Id.ToString();
            Date = show.Date;
            Title = show.Title;
            IconURL = show.IconURL;
            MovieId = show.MovieId.ToString();
            LengthMins = show.LengthMins;
            Genres = show.Genres.Select(x => x.ToString());
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
