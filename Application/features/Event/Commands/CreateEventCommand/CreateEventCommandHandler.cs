using AutoMapper;
using Domain;
using MediatR;
using Persistence.context;

namespace Application.features.Event.Commands.CreateEventCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly EventHubDbContext _dbContext;

        public CreateEventCommandHandler(IMapper mapper, EventHubDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<EventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var response = new EventCommandResponse();
            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;

                response.ValidationErrors = new List<string>();

                foreach(var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if(response.Success)
            {
                var eventToAdd = new Domain.Event()
                {
                    Title = request.EventDTO.Title,
                    Description = request.EventDTO.Description,
                    Location = request.EventDTO.Location,
                    Date = request.EventDTO.Date
                };

                await _dbContext.Events.AddAsync(eventToAdd);
                await _dbContext.SaveChangesAsync();
                response.EventDTO = _mapper.Map<EventDTO>(eventToAdd);
            }

            return response;
        }
    }
}
