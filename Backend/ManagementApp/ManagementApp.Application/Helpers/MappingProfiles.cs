using AutoMapper;
using ManagementApp.Application.Shared.Dtos.Departments;
using ManagementApp.Application.Shared.Dtos.Employees;
using ManagementApp.Application.Shared.Dtos.Positions;
using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom<EmployeeAgeResolver>())
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<CreatePositionDto, Position>();
            CreateMap<Position, PositionDto>();
        }
    }
}
