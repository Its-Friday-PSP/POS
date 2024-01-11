using API.Model;

namespace API.Services.Interfaces
{
    public interface IReservationService
    {
        public IEnumerable<ServiceTimeSlots> GetAllFreeReservations();
        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromService(Guid id);
        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromEmployee(Guid id);
        public Service? InsertReservationToService(ServiceTimeSlots timeSlot, Guid id);
        public Employee? InsertReservationToEmployee(ServiceTimeSlots timeSlot, Guid id);
    }
}
