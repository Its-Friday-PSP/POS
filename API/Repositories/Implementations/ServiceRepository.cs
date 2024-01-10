using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        public Service CreateService(Service service)
        {
            throw new NotImplementedException();
        }

        public Service DeleteService(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public Service GetService(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetServices(IEnumerable<Guid> serviceIds)
        {
            throw new NotImplementedException();
        }

        public Service UpdateService(Guid serviceId, Service service)
        {
            throw new NotImplementedException();
        }
    }
}
