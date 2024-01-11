using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Reservation
{
    public class GetServiceReservationTimesRequest
    {
        [FromRoute(Name ="serviceId")]
        public Guid ServiceId { get; set; }
    }
}