using MediatR;

namespace Application.features.Event.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListDTO>>
    {
    }
}
