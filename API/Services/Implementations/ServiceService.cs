using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service CreateService(Service service, List<ServiceTimeSlots> timeSlots)
        {
            return _serviceRepository.CreateService(service, timeSlots);
        }

        public bool DeleteService(Guid serviceId)
        {
            return _serviceRepository.DeleteService(serviceId);
        }

        public Service GetService(Guid serviceId)
        {
            return _serviceRepository.GetService(serviceId);
        }

        public Service UpdateService(Guid serviceId, Service service)
        {
            return _serviceRepository.UpdateService(serviceId, service);
        }
    }
}
