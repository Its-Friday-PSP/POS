using API.DTOs;
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
            Employee? employeeToReturn = null;
            try
            {
                employeeToReturn = _employeesService.CreateEmployee(_mapper.Map<Employee>(request.Employee));
                return Ok(new CreateEmployeeRequest(_mapper.Map<EmployeeDTO>(employeeToReturn));
            }
            catch (EmailAlreadyRegisteredException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetEmployeeResponse> GetEmployee([FromRoute] GetEmployeeRequest request)
        {
            var employee = _employeesService.GetEmployee(request.EmployeeId);
            var response = new GetEmployeeResponse(_mapper.Map<EmployeeDTO>(employee));
            return Ok(response);
        }
    }
}
