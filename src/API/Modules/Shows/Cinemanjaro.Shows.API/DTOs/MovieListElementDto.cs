using Cinemanjaro.Shows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.DTOs
{
    public class MovieListElementDto
    {
        public string Id { get; set; }
        public string IconURL { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Title { get; set; }

        public MovieListElementDto()
        {

        }

        public MovieListElementDto(Movie movie)
        {
            Id = movie.MovieId.ToString();
            IconURL = movie.IconURL;
            Genres = movie.Genres.Select(x => x.ToString());
            Title = movie.Title;
        }
        
    }
}
