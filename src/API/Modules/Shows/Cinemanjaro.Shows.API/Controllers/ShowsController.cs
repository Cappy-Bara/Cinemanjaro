using Cinemanjaro.Shows.API.DTOs;
using Cinemanjaro.Shows.Application.Shows.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanjaro.Shows.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/date/{date}")]
        public async Task<ActionResult<IEnumerable<ShowListDto>>> GetShowsOfDate(DateOnly date)
        {
            var query = new GetShowsOfDate(date);

            var shows = await _mediator.Send(query);

            if (shows.Any())
                return Ok(shows);

            return NoContent();
        }


        [HttpGet("/{id}")]
        public async Task<ActionResult<IEnumerable<ShowListDto>>> GetShowDetails(Guid id)
        {
            var query = new GetShow(id);

            var show = await _mediator.Send(query);

            if (show != null)
                return Ok(show);

            return NoContent();
        }
    }
}
