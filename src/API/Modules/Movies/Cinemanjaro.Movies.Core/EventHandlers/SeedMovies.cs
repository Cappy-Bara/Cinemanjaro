using Cinemanjaro.Jobs.Events;
using Cinemanjaro.Movies.Core.DataAccessLayer.Storages;
using Cinemanjaro.Movies.Core.Entities;
using Cinemanjaro.Movies.Core.Enums;
using MediatR;
using MongoDB.Bson;

namespace Cinemanjaro.Movies.Core.EventHandlers
{
    public class SeedMovies : INotificationHandler<DataSeeded>
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IMoviesStorage moviesStorage;

        public SeedMovies(IMoviesRepository moviesRepository, IMoviesStorage moviesStorage)
        {
            this.moviesRepository = moviesRepository;
            this.moviesStorage = moviesStorage;
        }

        public async Task Handle(DataSeeded notification, CancellationToken cancellationToken)
        {
            var movies = await moviesStorage.GetAll();

            if (movies is null || !movies.Any())
            {
                Console.WriteLine("Movies seeded");
                await moviesRepository.InsertMany(GetSeedData());
            }
        }

        private static IEnumerable<Movie> GetSeedData()
        {
            yield return new Movie()
            {
                Id = ObjectId.Parse("6259aaa9a553fadc6b929ec8"),
                Title = "Dune",
                Description = "A mythic and emotionally charged hero's journey, Dune tells the story of Paul Atreides, a brilliant and gifted young man born into a great destiny beyond his understanding, who must travel to the most dangerous planet in the universe to ensure the future of his family and his people. As malevolent forces explode into conflict over the planet's exclusive supply of the most precious resource in existence-a commodity capable of unlocking humanity's greatest potential-only those who can conquer their fear will survive.",
                Directors = new List<string> { "Denis Villeneuve" },
                Writers = new List<string> { "Jon Spaihts", "Denis Villeneuve", "Eric Roth" },
                Actors = new List<string> { "Timothee Chalamet", "Revecca Ferguson", "Zendaya", "Oscar Isaac", "Jason Momoa" },
                Genres = new List<Genre> { Genre.SciFi, Genre.Action, Genre.Drama },
                LengthMins = 155,
                Rate = 8.81,
                IMDBLink = "https://www.imdb.com/title/tt1160419/",
                FilmwebLink = "https://www.filmweb.pl/film/Diuna-2021-469476",
                ReleaseYear = 2021,
                PhotoURL = "https://fwcdn.pl/fph/94/76/469476/924841_1.3.jpg",
            };

            yield return new Movie()
            {
                Id = ObjectId.Parse("625ac72bba7d04d20d80da11"),
                Title = "Drive My Car",
                Description = "Two years after his wife's unexpected death, Yusuke Kafuku (Hidetoshi Nishijima), a renowned stage actor and director, receives an offer to direct a production of Uncle Vanya at a theater festival in Hiroshima. There, he meets Misaki Watari (Toko Miura), a taciturn young woman assigned by the festival to chauffeur him in his beloved red Saab 900. As the production's premiere approaches, tensions mount amongst the cast and crew, not least between Yusuke and Koshi Takatsuki, a handsome TV star who shares an unwelcome connection to Yusuke's late wife. Forced to confront painful truths raised from his past, Yusuke begins - with the help of his driver - to face the haunting mysteries his wife left behind.",
                Directors = new List<string> { "Ryûsuke Hamaguchi" },
                Writers = new List<string> { "Haruki Murakami", "Ryûsuke Hamaguchi", "Takamasa Oe" },
                Actors = new List<string> { "Hidetoshi Nishijima", "Tôko Miura", "Reika Kirishima"},
                Genres = new List<Genre> { Genre.Romance, Genre.Drama },
                LengthMins = 179,
                Rate = 7.66,
                IMDBLink = "https://www.imdb.com/title/tt14039582/",
                FilmwebLink = "https://www.filmweb.pl/film/Drive+My+Car-2021-875490",
                ReleaseYear = 2021,
                PhotoURL = "https://fwcdn.pl/fph/54/90/875490/1059281_1.3.jpg",
            };

            yield return new Movie()
            {
                Id = ObjectId.Parse("625ac89bba7d04d20d80da12"),
                Title = "Forrest Gump",
                Description = "Forrest Gump is a simple man with a low I.Q. but good intentions. He is running through childhood with his best and only friend Jenny. His 'mama' teaches him the ways of life and leaves him to choose his destiny. Forrest joins the army for service in Vietnam, finding new friends called Dan and Bubba, he wins medals, creates a famous shrimp fishing fleet, inspires people to jog, starts a ping-pong craze, creates the smiley, writes bumper stickers and songs, donates to people and meets the president several times. However, this is all irrelevant to Forrest who can only think of his childhood sweetheart Jenny Curran, who has messed up her life. Although in the end all he wants to prove is that anyone can love anyone.",
                Directors = new List<string> { "Robert Zemeckis" },
                Writers = new List<string> { "Winston Groom", "Eric Roth" },
                Actors = new List<string> { "Tom Hanks", "Robin Wright", "Gary Sinise"},
                Genres = new List<Genre> { Genre.Drama, Genre.Romance},
                LengthMins = 142,
                Rate = 8.8,
                IMDBLink = "https://www.imdb.com/title/tt0109830/?ref_=fn_al_tt_1",
                FilmwebLink = "https://www.filmweb.pl/film/Forrest+Gump-1994-998",
                ReleaseYear = 1994,
                PhotoURL = "https://fwcdn.pl/fpo/09/98/998/7314731.6.jpg",
            };

            yield return new Movie()
            {
                Id = ObjectId.Parse("625acb53ba7d04d20d80da13"),
                Title = "Inception",
                Description = "Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb's rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible, inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea, but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming.",
                Directors = new List<string> { "Christopher Nolan" },
                Writers = new List<string> { "Christopher Nolan" },
                Actors = new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page" },
                Genres = new List<Genre> { Genre.SciFi, Genre.Thriller},
                LengthMins = 148,
                Rate = 8.8,
                IMDBLink = "https://www.imdb.com/title/tt1375666/?ref_=tt_sims_tt_i_2",
                FilmwebLink = "https://www.filmweb.pl/film/Incepcja-2010-500891",
                ReleaseYear = 2010,
                PhotoURL = "https://fwcdn.pl/fph/08/91/500891/225032.3.jpg",
            };

            yield return new Movie()
            {
                Id = ObjectId.Parse("625acd1cba7d04d20d80da14"),
                Title = "Don't look up",
                Description = "Kate Dibiasky (Jennifer Lawrence), an astronomy grad student, and her professor Dr. Randall Mindy (Leonardo DiCaprio) make an astounding discovery of a comet orbiting within the solar system. The problem - it's on a direct collision course with Earth. The other problem? No one really seems to care. Turns out warning mankind about a planet-killer the size of Mount Everest is an inconvenient fact to navigate. With the help of Dr. Oglethorpe (Rob Morgan), Kate and Randall embark on a media tour that takes them from the office of an indifferent President Orlean (Meryl Streep) and her sycophantic son and Chief of Staff, Jason (Jonah Hill), to the airwaves of The Daily Rip, an upbeat morning show hosted by Brie (Cate Blanchett) and Jack (Tyler Perry). With only six months until the comet makes impact, managing the 24-hour news cycle and gaining the attention of the social media obsessed public before it's too late proves shockingly comical - what will it take to get the world to just look up?",
                Directors = new List<string> { "Adam McKay" },
                Writers = new List<string> { "Adam McKay", "David Sirota"},
                Actors = new List<string> { "Leonardo DiCaprio", "Jennifer Lawrence", "Meryl Streep", "Cate Blanchett"},
                Genres = new List<Genre> { Genre.Comedy, Genre.SciFi, Genre.Drama },
                LengthMins = 138,
                Rate = 7.2,
                IMDBLink = "https://www.imdb.com/title/tt11286314/?ref_=hm_tpks_tt_t_2_pd_tp1_cp",
                FilmwebLink = "https://www.filmweb.pl/film/Nie+patrz+w+g%C3%B3r%C4%99-2021-848823",
                ReleaseYear = 2021,
                PhotoURL = "https://fwcdn.pl/fph/88/23/848823/1025183_1.3.jpg",
            };
        }
    }
}
