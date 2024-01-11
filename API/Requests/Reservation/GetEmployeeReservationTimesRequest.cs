using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Reservation
{
    public class GetEmployeeReservationTimesRequest
    {
        [FromRoute(Name = "employeeId")]
        public Guid EmployeeId { get; set; }
    }
}