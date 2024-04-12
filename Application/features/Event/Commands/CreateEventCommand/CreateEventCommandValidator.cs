using FluentValidation;

namespace Application.features.Event.Commands.CreateEventCommand
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(x => x.EventDTO.Date).Must(x => x.Date > DateTime.UtcNow);
            RuleFor(x => x.EventDTO.Title).NotEmpty().MaximumLength(50);
        }
    }
}
