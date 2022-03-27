using Cinemanjaro.Shows.API.DTOs;
using Cinemanjaro.Shows.Application.Shows.Commands;
using Cinemanjaro.Shows.Application.Shows.Queries;
using Cinemanjaro.Shows.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<ShowListDto>>> GetShowsOfDate([FromRoute]DateTime date)
        {
            var query = new GetShowsOfDate(DateOnly.FromDateTime(date));

            var shows = await _mediator.Send(query);

            if (shows.Any())
                return Ok(shows);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ShowListDto>>> GetShowDetails([FromRoute]string id)
        {
            var objectId = ObjectId.Parse(id);
            var query = new GetShow(objectId);

            var show = await _mediator.Send(query);

            if (show != null)
                return Ok(show);

            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<ShowListDto>>> BookSeat([FromRoute] string id,[FromBody]BookSeatsDto dto)
        {
            var objectId = ObjectId.Parse(id);

            var seats = dto.SeatPositions.Select(x => new SeatPosition(x.Row, x.Number));

            var query = new BookSeats(seats, dto.Email, objectId);
            await _mediator.Send(query);

            return Ok();
        }
    }
}
