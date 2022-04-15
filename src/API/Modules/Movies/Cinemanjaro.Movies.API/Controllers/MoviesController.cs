using Cinemanjaro.Movies.API.DTOs;
using Cinemanjaro.Movies.Core.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
        public async Task<ActionResult<MovieDto>> Get([FromRoute] string id)
        {
            var objectId = ObjectId.Parse(id);

            var movie =  await _moviesService.GetMovieDetails(objectId);
            if (movie == null)
                return NoContent();

            var output = new MovieDto(movie);
            return Ok(output);
        }
    }
}
