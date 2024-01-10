using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        public Service CreateService(Service service, List<ServiceTimeSlots> timeSlots);
        public Service GetService(Guid serviceId);
        public Service UpdateService(Guid serviceId, Service service);
        public bool DeleteService(Guid serviceId);
    }
}
