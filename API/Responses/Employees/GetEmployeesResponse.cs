using API.DTOs;

namespace API.Responses.Employees
{
    public class GetEmployeesResponse
    {
        public List<EmployeeDTO> Employees { get; set; }

        public GetEmployeesResponse(List<EmployeeDTO> employee)
        {
            Employees = employee;
        }
    }
}
