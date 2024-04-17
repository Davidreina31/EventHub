using AutoMapper;
using MediatR;
using Persistence.context;

namespace Application.features.Event.Queries.GetDetailedEvent
{
    public class GetEventDetailedQueryHandler : IRequestHandler<GetEventDetailedQuery, EventDetailedDTO>
    {
        private readonly EventHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventDetailedQueryHandler(IMapper mapper, EventHubDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<EventDetailedDTO> Handle(GetEventDetailedQuery request, CancellationToken cancellationToken)
        {
            var detailedEvent = await _dbContext.Events.FindAsync(request.Id);

            return _mapper.Map<EventDetailedDTO>(detailedEvent);
        }
    }
}
