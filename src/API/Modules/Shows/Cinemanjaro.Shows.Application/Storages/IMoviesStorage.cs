using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.Application.Storages
{
    public interface IMoviesStorage
    {
        Task<IEnumerable<Movie>> GetMoviesOnScreen();
    }
}
