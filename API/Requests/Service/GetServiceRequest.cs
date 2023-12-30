using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Service
{
    public class GetServiceRequest
    {
        [FromRoute(Name = "serviceId")]
        public Guid ServiceId { get; set; }
    }
}
