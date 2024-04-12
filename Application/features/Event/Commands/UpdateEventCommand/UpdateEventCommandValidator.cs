using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Event.Commands.UpdateEventCommand
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.EventDTO.Date).Must(x => x.Date > DateTime.UtcNow);
            RuleFor(x => x.EventDTO.Title).NotEmpty().MaximumLength(50);
        }
    }
}
