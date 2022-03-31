using Cinemanjaro.Shows.Domain.Aggregates;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class ShowDto
    {
        public string Id { get; init; }
        public DateTime Date { get; init; }
        public string Title { get; init; }
        public IEnumerable<SeatDto> Positions { get; init; }    

        public ShowDto(Show show)
        {
            Id = show.Id.ToString();
            Date = show.Date;
            Title = show.Title;
            Positions = show.Seats.Select(x => new SeatDto(x));
        }
    }
}
