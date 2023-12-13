using AutoMapper;
using ManagementApp.Application.Features.Departments.Commands.CreateDepartment;
using ManagementApp.Application.Features.Employees.Commands.CreateEmployee;
using ManagementApp.Application.Features.Positions.Commands.CreatePosition;
using ManagementApp.Application.Shared.Dtos;
using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom<EmployeeAgeResolver>())
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<CreatePositionCommand, Position>();
            CreateMap<Position, PositionDto>();
        }
    }
}
