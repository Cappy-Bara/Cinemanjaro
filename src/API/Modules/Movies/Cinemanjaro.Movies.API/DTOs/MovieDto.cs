using Cinemanjaro.Movies.Core.Entities;
using Cinemanjaro.Movies.Core.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Movies.API.DTOs
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Directors { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Writers { get; set; }
        public int LengthMins { get; set; }
        public double Rate { get; set; }
        public int ReleaseYear { get; set; }
        public string IMDBLink { get; set; }
        public string PhotoURL { get; set; }


        public MovieDto()
        { 
        }

        public MovieDto(Movie movie)
        {
            Id = movie.Id.ToString();
            Title = movie.Title;    
            Description = movie.Description;
            Directors = movie.Directors;
            Actors = movie.Actors;
            Genres = movie.Genres.Select(x => x.ToString());
            Writers = movie.Writers;
            LengthMins = movie.LengthMins;
            Rate = movie.Rate;
            ReleaseYear = movie.ReleaseYear;
            IMDBLink = movie.IMDBLink;
            PhotoURL = movie.PhotoURL;
        }
    }
}
