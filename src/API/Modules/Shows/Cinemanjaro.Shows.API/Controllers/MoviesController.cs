using Cinemanjaro.Shows.API.DTOs;
using Cinemanjaro.Shows.Application.Movies.Queries;
using Cinemanjaro.Shows.Application.Shows.Commands;
using Cinemanjaro.Shows.Application.Shows.Queries;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
