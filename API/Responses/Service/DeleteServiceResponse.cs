using API.DTOs;

namespace API.Responses.Service
{
    public class DeleteServiceResponse
    {
        public ServiceDTO Service { get; set; }

        public DeleteServiceResponse(ServiceDTO service)
        {
            Service = service;
        }
    }
}
