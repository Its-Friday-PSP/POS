using API.DTOs;

namespace API.Responses.Service
{
    public class CreateServiceResponse
    {
        public ServiceDTO Service { get; set; }

        public CreateServiceResponse(ServiceDTO service)
        {
            Service = service;
        }
    }
}
