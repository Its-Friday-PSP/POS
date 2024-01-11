using API.DTOs;

namespace API.Responses.Reservation
{
    public class GetAllServicesResponse
    {
        public List<ServiceDTO> Services { get; set; }

        public GetAllServicesResponse(List<ServiceDTO> services)
        {
            Services = services;
        }
    }
}
