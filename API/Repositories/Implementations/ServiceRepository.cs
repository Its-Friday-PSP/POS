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

        //public Service CreateService(Service service)
        //{
        //    _context.Services.Add(service);
        //    _context.SaveChanges();

        //    return service;
        //}

        public Service CreateService(Service service, List<ServiceTimeSlots> timeSlots)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                // Add the Services
                _context.Add(service);
                _context.SaveChanges();

                //await _context.SaveChangesAsync();

                foreach (var timeSlot in service.ServiceTimeSlots)
                {
                    timeSlot.Id = new Guid();
                    timeSlot.ServiceId = service.Id; // Set the ServiceId to the newly created Service
                    
                    //_context.ServiceTimeSlots.Add(timeSlot);

                    _context.Add(timeSlot);
                }

                //await _context.SaveChangesAsync();
                _context.SaveChanges();

                //await transaction.CommitAsync();

                //transaction.Commit();

                return service; 
            }
            catch (Exception)
            {
                //await transaction.RollbackAsync();
                //transaction.Rollback();

                throw;
            }
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
