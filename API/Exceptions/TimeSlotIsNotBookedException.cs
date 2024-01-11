using System.Net;

namespace API.Exceptions
{
    public class TimeSlotAlreadyBookedException : HttpResponseException
    {
        private static readonly string message = "Time slot is already booked";
        public TimeSlotAlreadyBookedException() : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}