using Application.contracts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.features.Event.Commands.CreateEventCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventCommandResponse>
    {
        private readonly IWriteRepository<Domain.Event> _repo;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IWriteRepository<Domain.Event> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

                eventToAdd = await _repo.Create(eventToAdd);
                response.EventDTO = _mapper.Map<EventDTO>(eventToAdd);
            }

            return response;
        }
    }
}
