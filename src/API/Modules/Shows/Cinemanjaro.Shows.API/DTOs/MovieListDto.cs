using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class MovieListDto
    {
        public IEnumerable<MovieListElementDto> Movies { get; set; }

        public MovieListDto()
        {

        }

        public MovieListDto(IEnumerable<Movie> movies)
        {
            Movies = movies.Select(x => new MovieListElementDto(x));
        }
    }
}
