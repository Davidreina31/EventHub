using MediatR;

namespace Application.features.Event.Queries.GetDetailedEvent
{
    public class GetEventDetailedQuery : IRequest<EventDetailedDTO>
    {
        public Guid Id { get; set; }
    }
}
