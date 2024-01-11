using API.Enumerators;
using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        public IEnumerable<ServiceTimeSlots> GetAllFreeReservations();
        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromService(Guid id);
        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromEmployee(Guid id);
        public Service? InsertReservationToService(ServiceTimeSlots timeSlot, Guid id);
        public Employee? InsertReservationToEmployee(ServiceTimeSlots timeSlot, Guid id);
        public ServiceTimeSlots MakeReservation(Guid timeSlotId, Guid customerId);
        public ServiceTimeSlots CancelReservation(Guid timeSlotId, Guid CustomerId);
    }
}
