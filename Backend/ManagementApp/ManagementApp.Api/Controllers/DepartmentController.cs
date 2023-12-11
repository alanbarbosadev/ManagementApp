using AutoMapper;
using ManagementApp.Api.ViewModels.Department;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<DepartmentViewModel>>> GetAllDepartments()
        {
            return Ok(_mapper.Map<IReadOnlyList<DepartmentViewModel>>(await _departmentRepository.GetAllAsync()));
        }

        [HttpPost("create")]
        public async Task<ActionResult<DepartmentViewModel>> CreateDepartment(CreateDepartmentViewModel createDepartmentViewModel)
        {
            var department = _mapper.Map<Department>(createDepartmentViewModel);

            await _departmentRepository.AddAsync(department);

            return Ok(_mapper.Map<DepartmentViewModel>(department));
        }
    }
}
