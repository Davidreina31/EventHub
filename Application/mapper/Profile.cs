using Application.features.Event.Commands;
using Application.features.Event.Queries.GetDetailedEvent;
using Application.features.Event.Queries.GetEventList;
using Domain;

namespace Application.mapper
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Event, EventListDTO>().ReverseMap();
            CreateMap<Event, EventDetailedDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
        }
    }
}
