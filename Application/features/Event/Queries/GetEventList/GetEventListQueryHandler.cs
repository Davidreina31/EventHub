using Application.contracts;
using AutoMapper;
using MediatR;

namespace Application.features.Event.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListDTO>>
    {
        private readonly IReadRepository<Domain.Event> _repo;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IReadRepository<Domain.Event> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EventListDTO>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var events = await _repo.GetAll();

            return _mapper.Map<List<EventListDTO>>(events);
        }
    }
}
