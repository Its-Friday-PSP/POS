using API.Model;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;

        public ReservationRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<ServiceTimeSlots> GetAllFreeReservations()
        {
            return _context.ServiceTimeSlots.ToList().FindAll(x => !x.IsBooked);
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromService(Guid id)
        {
            return _context.ServiceTimeSlots.ToList().FindAll(x => x.ServiceId == id && !x.IsBooked);
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromEmployee(Guid id)
        {
            return _context.ServiceTimeSlots.ToList().FindAll(x => x.EmployeeId == id && !x.IsBooked);
        }

        public Service? InsertReservationToService(ServiceTimeSlots timeSlot, Guid id)
        {
            var service =_context.Services.Find(id);
            if (service == null)
                return null;

            if (service.ServiceTimeSlots == null)
                service.ServiceTimeSlots = new List<ServiceTimeSlots>();

            timeSlot.Id = new Guid();
            timeSlot.ServiceId = id;
            service.ServiceTimeSlots.Add(timeSlot);
            _context.Entry(service).State = EntityState.Modified;
            var a = _context.Entry(service);
            _context.SaveChanges();
            return service;
        }

        public Employee? InsertReservationToEmployee(ServiceTimeSlots timeSlot, Guid id)
        {
            var employee =_context.Employees.Find(id);
            if (employee == null)
                return null;

            if (employee.ServiceTimeSlots == null)
                employee.ServiceTimeSlots = new List<ServiceTimeSlots>();

            timeSlot.Id = new Guid();
            timeSlot.EmployeeId = id;
            employee.ServiceTimeSlots.Add(timeSlot);
            var a = _context.Entry(employee);
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            
            return employee;
        }
    }

}
