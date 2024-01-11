using System.Net;

namespace API.Exceptions
{
    public class CancelPastReservationException : HttpResponseException
    {
        private static readonly string message = "Can't cancel past reservation";
        public CancelPastReservationException() : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}