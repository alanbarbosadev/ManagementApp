using FluentValidation;
using ManagementApp.Application.Shared.Validations.Auth;

namespace ManagementApp.Application.Features.Auth.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.loginRequest).SetValidator(new LoginRequestValidation());
        }
    }
}
