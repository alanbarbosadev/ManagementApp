using FluentValidation;
using ManagementApp.Application.Shared.Validations.Departments;

namespace ManagementApp.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.departmentDto).SetValidator(new CreateDepartmentValidation());
        }
    }
}
