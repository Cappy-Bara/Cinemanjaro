﻿using Cinemanjaro.Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.Core.DataAccessLayer.Storages
{
    public interface IMoviesStorage
    {
        public Task<IEnumerable<Movie>> GetAll();
    }
}
