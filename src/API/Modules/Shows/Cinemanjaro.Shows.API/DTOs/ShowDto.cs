using Cinemanjaro.Shows.Domain.Aggregates;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowDto
    {
        public string Id { get; init; }
        public DateTime Date { get; init; }
        public string Title { get; init; }
        public string IconURL { get; set; }
        public string MovieId { get; set; }
        public int LengthMins { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<SeatDto> Seats { get; init; }    

        public ShowDto(Show show)
        {
            Id = show.Id.ToString();
            Date = show.Date;
            Title = show.Title;
            Seats = show.Seats.Select(x => new SeatDto(x));
            IconURL = show.IconURL;
            MovieId = show.MovieId.ToString();
            LengthMins = show.LengthMins;
            Genres = show.Genres.Select(x => x.ToString());
        }
    }
}
