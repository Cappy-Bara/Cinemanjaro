using Cinemanjaro.Movies.Core.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.Entities
{
    public class Movie
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Directors { get; set; }
        public IEnumerable<string> Writers { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public int LengthMins { get; set; }
        public double Rate { get; set; }
        public int ReleaseYear { get; set; }
        public string IMDBLink { get; set; }
        public string FilmwebLink { get; set; }
    }
}
