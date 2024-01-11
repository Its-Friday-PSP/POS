using System.Net;

namespace API.Exceptions
{
    public class TimeSlotIsNotBookedException : HttpResponseException
    {
        private static readonly string message = "Time slot is not booked";
        public TimeSlotIsNotBookedException() : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}