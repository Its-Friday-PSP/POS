using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Employees
{
    public class GetEmployeeRequest
    {
        [FromRoute(Name="customerId")]
        public Guid EmployeeId { get; set; }
    }
}
