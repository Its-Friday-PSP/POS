using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("services")]
    public class ServiceController : ControllerBase
    {

        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("{serviceId}")]
        public ActionResult<IEnumerable<Service>> GetService(Guid serviceId)
        {
            return Ok(_serviceService.GetService(serviceId));
        }

        [HttpPost]
        public ActionResult<Service> CreateService(Service service)
        {
            return Ok(_serviceService.CreateService(service));
        }

        [HttpPut("{serviceId}")]
        public ActionResult<Service> UpdateService(
            [FromQuery] Guid serviceId,
            [FromBody] Service service)
        {
            return Ok(_serviceService.UpdateService(serviceId, service));
        }

        [HttpDelete("{serviceId}")]
        public ActionResult<Service> DeleteService(Guid serviceId)
        {
            return Ok(_serviceService.DeleteService(serviceId));
        }
    }
}