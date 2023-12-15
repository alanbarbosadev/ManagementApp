using FluentValidation;
using ManagementApp.Application.Features.Auth.Commands.Register;

namespace ManagementApp.Application.Shared.Validations.Auth
{
    public class RegisterRequestValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidation()
        {
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop).NotNull().NotEmpty().MinimumLength(6).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{6,}$").WithMessage("Password must have at least 6 characters, 1 uppercase, 1 lowercase, 1 number and 1 non-alphanumeric value.");
            RuleFor(x => x.UserName).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.DisplayName).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}
