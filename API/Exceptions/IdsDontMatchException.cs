using System.Net;

namespace API.Exceptions
{
    public class IdsDontMatchException : HttpResponseException
    {
        private static readonly string message = "Provided id does not match with id in the entity";
        public IdsDontMatchException() : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}