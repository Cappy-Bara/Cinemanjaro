﻿using Cinemanjaro.Movies.Core.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.Services
{
    public interface IMovieService
    {
        public Task<Movie> GetMovieDetails(ObjectId id);
    }
}
