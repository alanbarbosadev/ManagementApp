using AutoMapper;
using ManagementApp.Api.ViewModels;
using ManagementApp.Api.ViewModels.Department;
using ManagementApp.Api.ViewModels.Employee;
using ManagementApp.Api.ViewModels.Position;
using ManagementApp.Domain.Models;
using ManagementApp.Domain.Models.Identity;

namespace ManagementApp.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Position, PositionViewModel>();
            CreateMap<CreatePositionViewModel, Position>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<CreateDepartmentViewModel, Department>();
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom<EmployeeAgeResolver>())
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<AppUser, UserViewModel>();
        }
    }
}
