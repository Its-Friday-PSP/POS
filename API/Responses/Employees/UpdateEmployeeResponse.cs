using API.DTOs;

namespace API.Responses.Employees
{
    public class UpdateEmployeeResponse
    {
        public EmployeeDTO Employee { get; set; }

        public UpdateEmployeeResponse(EmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
