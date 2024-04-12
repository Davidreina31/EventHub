using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.UpdateEventCommand
{
    public class UpdateEventCommand : IRequest<EventCommandResponse>
    {
        public Guid Id { get; set; }
        public EventDTO EventDTO { get; set; }
    }
}
