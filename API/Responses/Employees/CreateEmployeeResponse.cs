using API.DTOs;

namespace API.Responses.Employees
{
    public class CreateEmployeeResponse
    {
        public EmployeeDTO Employee { get; set; }
        
        public CreateEmployeeResponse(EmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
