using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Service
{
    public class UpdateServiceRequest
    {
        [FromQuery]
        public Guid ServiceId { get; set; }

        [FromBody]
        public ServiceDTO Service { get; set; }
    }
}
