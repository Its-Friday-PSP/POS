using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Reservation
{
    public class RemoveCustomerFromTheReservationRequest
    {
        [FromRoute(Name = "timeSlotId")]
        public Guid TimeSlotId { get; set; }
    }
}
