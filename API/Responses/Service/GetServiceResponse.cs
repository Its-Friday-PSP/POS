using API.DTOs;

namespace API.Responses.Service
{
    public class GetServiceResponse
    {
        public ServiceDTO Service { get; set; }

        public GetServiceResponse(ServiceDTO service)
        {
            Service = service;
        }
    }
}
