using FluentValidation;
using ManagementApp.Application.Shared.Validations.Auth;

namespace ManagementApp.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.registerRequest)
                .SetValidator(new RegisterRequestValidation());
        }
    }
}
