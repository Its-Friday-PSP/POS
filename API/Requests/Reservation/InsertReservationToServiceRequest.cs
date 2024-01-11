using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Reservation
{
    public class InsertReservationToServiceRequest
    {
        [FromBody]
        public ServiceTimeSlots TimeSlots { get; set; }
    }
}
