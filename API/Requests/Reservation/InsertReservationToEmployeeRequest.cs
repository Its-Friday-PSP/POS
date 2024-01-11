using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Reservation
{
    public class InsertReservationToEmployeeRequest
    {
        [FromBody]
        public ServiceTimeSlotsDTO TimeSlots { get; set; }
    }
}
