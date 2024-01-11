using API.DTOs;
using API.DTOs.Request;
using API.DTOs.Response;
using API.Exceptions;
using API.Model;
using API.Requests.Employees;
using API.Responses.Employees;
using API.Responses.Reservation;
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
        public ActionResult<EmployeeCreationResponseDTO> RegisterNewEmployee(EmployeeCreationRequestDTO request)
        {
            var employeeToReturn = _employeesService.CreateEmployee(_mapper.Map<Employee>(request));
            return employeeToReturn == null ? Unauthorized() : Ok(_mapper.Map<EmployeeDTO>(employeeToReturn));
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetEmployeeResponse> GetEmployee([FromRoute] GetEmployeeRequest request)
        {
            var employee = _employeesService.GetEmployee(request.EmployeeId);
            return employee == null ? NotFound() : Ok(new GetEmployeeResponse(_mapper.Map<EmployeeDTO>(employee)));
        }
        
        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdateEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request, [FromRoute] Guid employeeId)
        {
            var employee = _employeesService.UpdateEmployee(_mapper.Map<Employee>(request.Employee), employeeId);
            return employee == null ? NotFound() : Ok(new GetEmployeeResponse(_mapper.Map<EmployeeDTO>(employee)));
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEmployee([FromRoute] DeleteEmployeeRequest request)
        {
            return _employeesService.DeleteEmployee(request.EmployeeId) ? Ok() : NotFound();
        }
    }
}
