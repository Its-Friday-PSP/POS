using API.DTOs;

namespace API.Responses.Employees
{
    public class GetEmployeeResponse
    {
        public EmployeeDTO Employee { get; set; }

        public GetEmployeeResponse(EmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
