using Application.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.DeleteEventCommand
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IWriteRepository<Domain.Event> _repo;

        public DeleteEventCommandHandler(IWriteRepository<Domain.Event> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await _repo.Delete(request.Id);
        }
    }
}
