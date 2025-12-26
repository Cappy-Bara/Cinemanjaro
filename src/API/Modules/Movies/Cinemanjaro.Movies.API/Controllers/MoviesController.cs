using Cinemanjaro.Movies.API.DTOs;
using Cinemanjaro.Movies.Core.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Annotations;

namespace Cinemanjaro.Movies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _moviesService;
        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Returns information about selected movie")]
        public async Task<ActionResult<MovieDto>> GetSingle([FromRoute] string id)
        {
            var objectId = ObjectId.Parse(id);

            var movie =  await _moviesService.GetMovieDetails(objectId);
            if (movie == null)
                return NoContent();

            var output = new MovieDto(movie);
            return Ok(output);
        }

        [HttpGet("")]
        [SwaggerOperation("Get list of movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Get([FromQuery]int page = 1, [FromQuery] int pageSize = 12)
        {
            var movies = await _moviesService.GetMovies(page,pageSize);
            if (movies.data == null || !movies.data.Any())
                return NoContent();

            var data = movies.data.Select(x => new MovieShortDataDto(x));
            var output = new MoviesListResult
            {
                Movies = data.ToList(),
                Amount = movies.amount
            };

            return Ok(output);
        }
    }
}
