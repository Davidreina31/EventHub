using MediatR;

namespace Application.features.Event.Commands.CreateEventCommand
{
    public class CreateEventCommand : IRequest<EventCommandResponse>
    {
        public EventDTO EventDTO { get; set; }
    }
}
