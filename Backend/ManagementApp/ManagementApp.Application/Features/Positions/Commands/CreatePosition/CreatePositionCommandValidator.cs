using FluentValidation;
using ManagementApp.Application.Shared.Validations.Positions;

namespace ManagementApp.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(x => x.positionDto).SetValidator(new CreatePositionValidation());
        }
    }
}
