using Cinemanjaro.Jobs.Events;
using Cinemanjaro.Shows.Application.Storages;
using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Repositories;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MediatR;
using MongoDB.Bson;

namespace Cinemanjaro.Shows.Application.EventHandlers.Shows
{
    public class SeedShows : INotificationHandler<DataSeeded>
    {
        private readonly IShowsRepository showsRepository;
        private readonly IShowsStorage showsStorage;

        public SeedShows(IShowsRepository showsRepository, IShowsStorage showsStorage)
        {
            this.showsRepository = showsRepository;
            this.showsStorage = showsStorage;
        }

        public async Task Handle(DataSeeded notification, CancellationToken cancellationToken)
        {
            var availableShows = await showsStorage.GetShowsByDate(DateOnly.FromDateTime(DateTime.Now.ToUniversalTime()));
            
            if (availableShows is null || !availableShows.Any())
            {
                Console.WriteLine("Shows seeded");
                await showsRepository.CreateMany(GetSeedData());
            }
        }

        private static IEnumerable<Show> GetSeedData()
        {
            var baseDate = DateTime.Now.ToUniversalTime().Date.AddDays(1).AddHours(18);

            yield return new Show()
            {
                Title = "Don't look up",
                Date = baseDate,
                Genres = new List<Genre> { Genre.Comedy, Genre.Drama, Genre.SciFi },
                IconURL = "https://fwcdn.pl/fpo/88/23/848823/7983647.6.jpg",
                LengthMins = 138,
                MovieId = ObjectId.Parse("625acd1cba7d04d20d80da14"),
                Seats = new List<Seat>()
                {
                    new Seat(1,1),
                    new Seat(1,2),
                    new Seat(1,3),
                    new Seat(1,4),
                    new Seat(1,5),
                    new Seat(1,6),
                    new Seat(1,7),
                    new Seat(1,8),
                    new Seat(1,9),
                    new Seat(1,10),
                    new Seat(2,1),
                    new Seat(2,2),
                    new Seat(2,3),
                    new Seat(2,4),
                    new Seat(2,5),
                    new Seat(2,6),
                    new Seat(2,7),
                    new Seat(2,8),
                    new Seat(2,9),
                    new Seat(2,10),
                },
            };

            yield return new Show()
            {
                Title = "Inception",
                Date = baseDate.AddHours(2),
                Genres = new List<Genre> { Genre.Thriller, Genre.SciFi },
                IconURL = "https://fwcdn.pl/fpo/08/91/500891/7354571.6.jpg",
                LengthMins = 148,
                MovieId = ObjectId.Parse("625acb53ba7d04d20d80da13"),
                Seats = new List<Seat>()
                {
                    new Seat(1,1),
                    new Seat(1,2),
                    new Seat(1,3),
                    new Seat(1,4),
                    new Seat(1,5),
                    new Seat(1,6),
                    new Seat(1,7),
                    new Seat(1,8),
                    new Seat(1,9),
                    new Seat(1,10),
                    new Seat(2,1),
                    new Seat(2,2),
                    new Seat(2,3),
                    new Seat(2,4),
                    new Seat(2,5),
                    new Seat(2,6),
                    new Seat(2,7),
                    new Seat(2,8),
                    new Seat(2,9),
                    new Seat(2,10),
                },
            };

            yield return new Show()
            {
                Title = "Forrest Gump",
                Date = baseDate.AddHours(4),
                Genres = new List<Genre> { Genre.Drama, Genre.Romance },
                IconURL = "https://fwcdn.pl/fpo/09/98/998/7314731.6.jpg",
                LengthMins = 142,
                MovieId = ObjectId.Parse("625ac89bba7d04d20d80da12"),
                Seats = new List<Seat>()
                {
                    new Seat(1,1),
                    new Seat(1,2),
                    new Seat(1,3),
                    new Seat(1,4),
                    new Seat(1,5),
                    new Seat(1,6),
                    new Seat(1,7),
                    new Seat(1,8),
                    new Seat(1,9),
                    new Seat(1,10),
                    new Seat(2,1),
                    new Seat(2,2),
                    new Seat(2,3),
                    new Seat(2,4),
                    new Seat(2,5),
                    new Seat(2,6),
                    new Seat(2,7),
                    new Seat(2,8),
                    new Seat(2,9),
                    new Seat(2,10),
                },
            };

            yield return new Show()
            {
                Title = "Drive My Car",
                Date = baseDate,
                Genres = new List<Genre> { Genre.Drama, Genre.Romance },
                IconURL = "https://fwcdn.pl/fpo/54/90/875490/8000632.6.jpg",
                LengthMins = 179,
                MovieId = ObjectId.Parse("625ac72bba7d04d20d80da11"),
                Seats = new List<Seat>()
                {
                    new Seat(1,1),
                    new Seat(1,2),
                    new Seat(1,3),
                    new Seat(1,4),
                    new Seat(1,5),
                    new Seat(1,6),
                    new Seat(1,7),
                    new Seat(1,8),
                    new Seat(1,9),
                    new Seat(1,10),
                    new Seat(2,1),
                    new Seat(2,2),
                    new Seat(2,3),
                    new Seat(2,4),
                    new Seat(2,5),
                    new Seat(2,6),
                    new Seat(2,7),
                    new Seat(2,8),
                    new Seat(2,9),
                    new Seat(2,10),
                },
            };

            yield return new Show()
            {
                Title = "Dune",
                Date = baseDate.AddHours(-1),
                Genres = new List<Genre> { Genre.Drama, Genre.SciFi, Genre.Action },
                IconURL = "https://fwcdn.pl/fpo/94/76/469476/7972251.6.jpg",
                LengthMins = 155,
                MovieId = ObjectId.Parse("6259aaa9a553fadc6b929ec8"),
                Seats = new List<Seat>()
                {
                    new Seat(1,1),
                    new Seat(1,2),
                    new Seat(1,3),
                    new Seat(1,4),
                    new Seat(1,5),
                    new Seat(1,6),
                    new Seat(1,7),
                    new Seat(1,8),
                    new Seat(1,9),
                    new Seat(1,10),
                    new Seat(2,1),
                    new Seat(2,2),
                    new Seat(2,3),
                    new Seat(2,4),
                    new Seat(2,5),
                    new Seat(2,6),
                    new Seat(2,7),
                    new Seat(2,8),
                    new Seat(2,9),
                    new Seat(2,10),
                },
            };
        }

    }
}
