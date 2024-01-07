using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Employees
{
    public class UpdateEmployeeRequest
    {
        [FromBody]
        public EmployeeDTO Employee { get; set; }
    }
}
