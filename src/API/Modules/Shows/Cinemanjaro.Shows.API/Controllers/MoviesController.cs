using Cinemanjaro.Shows.API.DTOs;
using Cinemanjaro.Shows.Application.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cinemanjaro.Shows.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("on-screen")]
        [SwaggerOperation("Returns movies which are currently available to watch")]
        public async Task<ActionResult<MovieListDto>> GetMoviesOnScreen()
        {
            var query = new GetMoviesOnScreen();
            var output = await _mediator.Send(query);
            
            if (!output.Any())
                return NoContent();

            return Ok(new MovieListDto(output));
        }


    }
}
