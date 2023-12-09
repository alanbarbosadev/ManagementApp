using AutoMapper;
using ManagementApp.Api.ViewModels.Employee;
using ManagementApp.Domain.Models;

namespace ManagementApp.Api.Helpers
{
    public class EmployeeAgeResolver : IValueResolver<Employee, EmployeeViewModel, int>
    {
        public int Resolve(Employee source, EmployeeViewModel destination, int destMember, ResolutionContext context)
        {
            if (DateTime.Now > source.Birthday)
            {
                return DateTime.Now.Year - source.Birthday.Year;
            }
            else
            {
                return (DateTime.Now.Year - source.Birthday.Year) - 1;
            }
        }
    }
}
