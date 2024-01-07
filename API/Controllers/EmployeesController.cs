﻿using API.DTOs;
using API.Exceptions;
using API.Model;
using API.Requests.Employees;
using API.Responses.Employees;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService employeesService, IMapper mapper)
        {
            _employeesService = employeesService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CreateEmployeeResponse> RegisterNewEmployee(CreateEmployeeRequest request)
        {
            var employeeToReturn = _employeesService.CreateEmployee(_mapper.Map<Employee>(request.Employee));
            return employeeToReturn == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(new CreateEmployeeRequest(_mapper.Map<EmployeeDTO>(employeeToReturn)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetEmployeesResponse> GetEmployees()
        {
            var employees = _employeesService.GetAllEmployees();
            return Ok(new GetEmployeesResponse(_mapper.Map<List<EmployeeDTO>>(employees)));
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetEmployeeResponse> GetEmployee([FromRoute] GetEmployeeRequest request)
        {
            var employee = _employeesService.GetEmployee(request.EmployeeId);
            return employee == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(new GetEmployeeResponse(_mapper.Map<EmployeeDTO>(employee)));
        }
        
        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UpdateEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request, [FromRoute] Guid employeeId)
        {
            var employee = _employeesService.UpdateEmployee(_mapper.Map<Employee>(request.Employee), employeeId);
            return employee == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(new GetEmployeeResponse(_mapper.Map<EmployeeDTO>(employee)));
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteEmployee([FromRoute] DeleteEmployeeRequest request)
        {
            return _employeesService.DeleteEmployee(request.EmployeeId) ? Ok() : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
