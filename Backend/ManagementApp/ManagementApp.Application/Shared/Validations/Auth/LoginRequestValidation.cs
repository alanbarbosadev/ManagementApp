using FluentValidation;
using ManagementApp.Application.Features.Auth.Queries.Login;

namespace ManagementApp.Application.Shared.Validations.Auth
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty().EmailAddress();
        }
    }
}
