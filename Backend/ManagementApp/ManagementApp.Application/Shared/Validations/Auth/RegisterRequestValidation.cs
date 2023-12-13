using FluentValidation;
using ManagementApp.Application.Features.Auth.Commands.Register;

namespace ManagementApp.Application.Shared.Validations.Auth
{
    public class RegisterRequestValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidation()
        {
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotNull().NotEmpty().MinimumLength(6);
            RuleFor(x => x.DisplayName).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}
