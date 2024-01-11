using System.Net;

namespace API.Exceptions
{
    public class TimeSlotAlreadyBooked : HttpResponseException
    {
        private static readonly string message = "Time slot is already booked";
        public TimeSlotAlreadyBooked() : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}