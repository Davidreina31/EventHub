using MediatR;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.DeleteEventCommand
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly EventHubDbContext _dbContext;

        public DeleteEventCommandHandler(EventHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var objectToRemove = await _dbContext.Events.FindAsync(request.Id);

            _dbContext.Remove(objectToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }
}
