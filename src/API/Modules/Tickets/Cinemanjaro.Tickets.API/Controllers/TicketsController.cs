using Cinemanjaro.Common.DataProviders;
using Cinemanjaro.Tickets.API.DTOs;
using Cinemanjaro.Tickets.Application.Tickets.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemanjaro.Tickets.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserDataProvider _dataProvider;

        public TicketsController(IMediator mediator, IUserDataProvider dataProvider)
        {
            _mediator = mediator;
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<ActionResult<TicketsDto>> GetUserTickets()
        {
            var command = new GetAllUserTickets(_dataProvider.UserEmail());

            var values = await _mediator.Send(command);

            var output = new TicketsDto(values);
            return Ok(output);
        }
    }
}