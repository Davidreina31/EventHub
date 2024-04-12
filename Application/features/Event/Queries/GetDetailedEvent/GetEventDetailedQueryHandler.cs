using Application.contracts;
using AutoMapper;
using MediatR;

namespace Application.features.Event.Queries.GetDetailedEvent
{
    public class GetEventDetailedQueryHandler : IRequestHandler<GetEventDetailedQuery, EventDetailedDTO>
    {
        private readonly IReadRepository<Domain.Event> _repo;
        private readonly IMapper _mapper;

        public GetEventDetailedQueryHandler(IReadRepository<Domain.Event> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<EventDetailedDTO> Handle(GetEventDetailedQuery request, CancellationToken cancellationToken)
        {
            var detailedEvent = await _repo.GetById(request.Id);

            return _mapper.Map<EventDetailedDTO>(detailedEvent);
        }
    }
}
