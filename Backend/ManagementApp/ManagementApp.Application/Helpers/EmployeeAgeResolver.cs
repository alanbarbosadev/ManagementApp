using AutoMapper;
using ManagementApp.Application.Shared.Dtos;
using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Helpers
{
    public class EmployeeAgeResolver : IValueResolver<Employee, EmployeeDto, int>
    {
        public int Resolve(Employee source, EmployeeDto destination, int destMember, ResolutionContext context)
        {
            if (DateTime.Now > source.Birthday)
            {
                return DateTime.Now.Year - source.Birthday.Year;
            }
            else
            {
                return DateTime.Now.Year - source.Birthday.Year - 1;
            }
        }
    }
}
