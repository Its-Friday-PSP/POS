using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;
        private readonly IServiceRepository _serviceRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public ReservationRepository(Context context, IServiceRepository serviceRepository, IEmployeesRepository employeesRepository)
        {
            _context = context;
            _serviceRepository = serviceRepository;
            _employeesRepository = employeesRepository;
        }

        public IEnumerable<ServiceTimeSlots> GetAllFreeReservations()
        {
            IEnumerable<ServiceTimeSlots> freeSlots = new List<ServiceTimeSlots>();
            foreach (Service service in _serviceRepository.GetAllServices())
            {
                if (service.ServiceTimeSlots == null)
                    continue;

                foreach (ServiceTimeSlots slot in service.ServiceTimeSlots)
                {
                    if (!slot.IsBooked)
                        freeSlots.Append(slot);
                }
            }
            foreach (Employee employee in _employeesRepository.GetAllEmployees())
            {
                if (employee.ServiceTimeSlots == null)
                    continue;

                foreach (ServiceTimeSlots slot in employee.ServiceTimeSlots)
                {
                    if (!slot.IsBooked)
                        freeSlots.Append(slot);
                }
            }
            return freeSlots;
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromService(Guid id)
        {
            var service = _serviceRepository.GetService(id);
            if (service == null)
                return null;

            return service.ServiceTimeSlots.FindAll(slot => !slot.IsBooked);
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromEmployee(Guid id)
        {
            var employee = _employeesRepository.GetEmployee(id);
            if (employee == null)
                return null;

            return employee.ServiceTimeSlots.FindAll(slot => !slot.IsBooked);
        }

        public Service? InsertReservationToService(ServiceTimeSlots timeSlot, Guid id)
        {
            var service = _serviceRepository.GetService(id);
            if (service == null)
                return null;

            if (service.ServiceTimeSlots == null)
                service.ServiceTimeSlots = new List<ServiceTimeSlots>();

            service.ServiceTimeSlots.Add(timeSlot);
            _context.SaveChanges();
            return service;
        }

        public Employee? InsertReservationToEmployee(ServiceTimeSlots timeSlot, Guid id)
        {
            var employee = _employeesRepository.GetEmployee(id);
            if (employee == null)
                return null;

            if (employee.ServiceTimeSlots == null)
                employee.ServiceTimeSlots = new List<ServiceTimeSlots>();

            employee.ServiceTimeSlots.Add(timeSlot);
            _context.SaveChanges();
            return employee;
        }
    }

}
