using FluentValidation;
using ManagementApp.Application.Shared.Dtos.Departments;

namespace ManagementApp.Application.Shared.Validations.Departments
{
    public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentValidation()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}
