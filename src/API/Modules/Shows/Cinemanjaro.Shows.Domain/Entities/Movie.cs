using Cinemanjaro.Shows.Domain.ValueObjects;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Domain.Entities
{
    public class Movie
    {
        public ObjectId MovieId { get; set; }
        public string IconURL { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title { get; set; }
    }
}
