using API.DTOs;
using API.DTOs.Request;
using API.Model;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _context.Services.Include(x => x.Taxes).FirstOrDefault(x => x.Id == serviceId);
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services;
        }

        public IEnumerable<Service> GetServices(IEnumerable<Guid> serviceIds)
        {
            return _context.Services.Include(x => x.Taxes).Where(x => serviceIds.Contains(x.Id));
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
