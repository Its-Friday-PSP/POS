using API.DTOs.Request;
using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        public Service CreateService(Service service);
        public Service GetService(Guid serviceId);
        public IEnumerable<Service> GetAllServices();
        public IEnumerable<Service> GetServices(IEnumerable<Guid> serviceIds);
        public Service UpdateService(Guid serviceId, Service service);
        public bool DeleteService(Guid serviceId);
    }
}
