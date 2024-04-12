using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.DeleteEventCommand
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
