using Application.features.Event.Commands;
using Application.features.Event.Commands.CreateEventCommand;
using Application.features.Event.Commands.DeleteEventCommand;
using Application.features.Event.Commands.UpdateEventCommand;
using Application.features.Event.Queries.GetDetailedEvent;
using Application.features.Event.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventListDTO>>> GetEvents()
        {
            var dtos = await _mediator.Send(new GetEventListQuery());
            return Ok(dtos);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailedDTO>> GetById(Guid id)
        {
            var dto = await _mediator.Send(new GetEventDetailedQuery() { Id = id });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EventDTO>> Create(CreateEventCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult<EventDTO>> Update(UpdateEventCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteEventCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
