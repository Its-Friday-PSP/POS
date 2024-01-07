using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Employees
{
    public class GetEmployeeRequest
    {
        [FromRoute(Name="employeeId")]
        public Guid EmployeeId { get; set; }
    }
}
