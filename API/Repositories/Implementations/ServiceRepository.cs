using API.DTOs;
using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public Service CreateService(Service service)
        {       
                service.Id = Guid.NewGuid();
                _context.Add(service);
                _context.SaveChanges();

                return service; 
        }

        public bool DeleteService(Guid serviceId)
        {
            var service = GetService(serviceId);
            _context.Services.Remove(service);
            _context.SaveChanges();

            return true;
        }

        public Service GetService(Guid serviceId)
        {
            return _context.Services.Find(serviceId);
        }

        public Service UpdateService(Guid serviceId, Service service)
        {
            var existingService = GetService(serviceId);
            _context.Entry(existingService).CurrentValues.SetValues(service);
            _context.SaveChanges();

            return existingService;
        }
    }
}
