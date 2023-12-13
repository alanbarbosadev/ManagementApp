using FluentValidation;
using ManagementApp.Application.Shared.Validations.Employees;

namespace ManagementApp.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.employeeDto).SetValidator(new CreateEmployeeValidation());
        }
    }
}
