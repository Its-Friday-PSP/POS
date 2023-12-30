using System.Net;

namespace API.Exceptions
{
    public class EmailAlreadyRegisteredException : HttpResponseException
    {
        public EmailAlreadyRegisteredException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
