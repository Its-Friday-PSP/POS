using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Employees
{
    public class DeleteEmployeeRequest
    {
        [FromRoute(Name = "employeeId")]
        public Guid EmployeeId { get; set; }
    }
}
