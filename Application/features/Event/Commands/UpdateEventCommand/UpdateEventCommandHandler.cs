using AutoMapper;
using MediatR;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.UpdateEventCommand
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventCommandResponse>
    {
        private readonly EventHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IMapper mapper, EventHubDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<EventCommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var response = new EventCommandResponse();
            var validator = new UpdateEventCommandValidator();
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
                var eventToUpdate = new Domain.Event()
                {
                    Id = request.Id,
                    Title = request.EventDTO.Title,
                    Description = request.EventDTO.Description,
                    Location = request.EventDTO.Location,
                    Date = request.EventDTO.Date
                };

                _dbContext.Events.Update(eventToUpdate);
                await _dbContext.SaveChangesAsync();
                response.EventDTO = _mapper.Map<EventDTO>(eventToUpdate);
            }

            return response;
        }
    }
}
