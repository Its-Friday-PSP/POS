using API.DTOs;

namespace API.Responses.Service
{
    public class UpdateServiceResponse
    {
        public ServiceDTO Service { get; set; }

        public UpdateServiceResponse(ServiceDTO service)
        {
            Service = service;
        }
    }
}
