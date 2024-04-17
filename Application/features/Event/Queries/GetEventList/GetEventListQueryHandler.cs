using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.context;

namespace Application.features.Event.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListDTO>>
    {
        private readonly EventHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IMapper mapper, EventHubDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<EventListDTO>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var events = await _dbContext.Events.ToListAsync();

            return _mapper.Map<List<EventListDTO>>(events);
        }
    }
}
