using API.DTOs.Request;
using API.Model;

namespace API.Services.Interfaces
{
    public interface IServiceService
    {
        public Service CreateService(Service service, IEnumerable<Guid> taxes);
        public Service GetService(Guid serviceId);
        public Service UpdateService(Guid serviceId, Service service);
        public IEnumerable<Service> GetAllServices();
        public bool DeleteService(Guid serviceId);
    }
}
