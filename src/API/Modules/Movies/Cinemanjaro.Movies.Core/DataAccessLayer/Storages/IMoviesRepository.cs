using Cinemanjaro.Movies.Core.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.DataAccessLayer.Storages
{
    public interface IMoviesRepository
    {
        public Task<Movie> Get(ObjectId Id);

        public Task InsertMany(IEnumerable<Movie> movies);
    }
}
