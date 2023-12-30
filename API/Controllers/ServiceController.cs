using API.DTOs;
using API.Model;
using API.Requests.Service;
using API.Responses.Service;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("services")]
    public class ServiceController : ControllerBase
    {

        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet("{serviceId}")]
        public ActionResult<GetServiceResponse> GetService([FromRoute] GetServiceRequest request)
        {   
            var serviceDomain = _serviceService.GetService(request.ServiceId);
            var response = new GetServiceResponse(_mapper.Map<ServiceDTO>(serviceDomain));
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<CreateServiceResponse> CreateService(CreateServiceRequest request)
        {
            var serviceDomain = _mapper.Map<Service>(request.Service);
            var createdService = _serviceService.CreateService(serviceDomain);
            var response = new CreateServiceResponse(_mapper.Map<ServiceDTO>(createdService));
            return Ok(response);
        }

        [HttpPut("{serviceId}")]
        public ActionResult<UpdateServiceResponse> UpdateService(UpdateServiceRequest request)
        {
            var service = _mapper.Map<Service>(request.Service);
            var updateService = _serviceService.UpdateService(request.ServiceId, service);
            var response = new UpdateServiceResponse(_mapper.Map<ServiceDTO>(updateService));
            return Ok(response);
        }

        [HttpDelete("{serviceId}")]
        public ActionResult<DeleteServiceResponse> DeleteService(DeleteServiceRequest request)
        {
            var deletedService = _serviceService.DeleteService(request.ServiceId);
            var response = new DeleteServiceResponse(_mapper.Map<ServiceDTO>(deletedService));
            return Ok(response);
        }
    }
}