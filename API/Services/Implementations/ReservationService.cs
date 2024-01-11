using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public IEnumerable<ServiceTimeSlots> GetAllFreeReservations()
        {
            return _reservationRepository.GetAllFreeReservations();
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromService(Guid id)
        {
            return _reservationRepository.GetFreeReservationsFromService(id);
        }

        public IEnumerable<ServiceTimeSlots>? GetFreeReservationsFromEmployee(Guid id)
        {
            return _reservationRepository.GetFreeReservationsFromEmployee(id);
        }

        public Service? InsertReservationToService(ServiceTimeSlots timeSlot, Guid id)
        {
            return _reservationRepository.InsertReservationToService(timeSlot, id);
        }

        public Employee? InsertReservationToEmployee(ServiceTimeSlots timeSlot, Guid id)
        {
            return _reservationRepository.InsertReservationToEmployee(timeSlot, id);
        }
    }
}