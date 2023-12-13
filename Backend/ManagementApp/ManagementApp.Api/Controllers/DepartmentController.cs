using AutoMapper;
using ManagementApp.Application.Features.Departments.Commands.CreateDepartment;
using ManagementApp.Application.Features.Departments.Queries.GetAllDepartments;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Shared.Dtos;
using ManagementApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<DepartmentDto>>> GetAllDepartments()
        {
            return Ok(await _mediator.Send(new GetAllDepartmentsQuery()));
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            await _mediator.Send(createDepartmentCommand);

            return NoContent();
        }
    }
}
