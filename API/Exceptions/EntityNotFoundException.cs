using System.Net;

namespace API.Exceptions
{
    public class EntityNotFoundException : HttpResponseException
    {
        private static readonly string message = "Can't find entity with provided id";
        public EntityNotFoundException() : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}