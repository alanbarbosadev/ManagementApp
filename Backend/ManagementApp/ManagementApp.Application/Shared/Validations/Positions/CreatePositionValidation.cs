using FluentValidation;
using ManagementApp.Application.Shared.Dtos.Positions;

namespace ManagementApp.Application.Shared.Validations.Positions
{
    public class CreatePositionValidation : AbstractValidator<CreatePositionDto>
    {
        public CreatePositionValidation()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}
