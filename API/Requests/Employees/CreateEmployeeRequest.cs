using API.DTOs;

namespace API.Requests.Employees
{
    public class CreateEmployeeRequest
    {
        public EmployeeDTO Employee { get; set; }
        public CreateEmployeeRequest(EmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
