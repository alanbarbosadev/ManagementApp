using FluentValidation;
using ManagementApp.Application.Shared.Dtos.Employees;

namespace ManagementApp.Application.Shared.Validations.Employees
{
    public class CreateEmployeeValidation : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidation()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty().MinimumLength(10);
            RuleFor(x => x.Salary).Cascade(CascadeMode.Stop).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Birthday).LessThan(DateTime.Now);
            RuleFor(x => x.DepartmentId).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.PositionId).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}