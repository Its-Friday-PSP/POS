using API.DTOs;
namespace API.Requests.Reservation
{
    public class InsertReservationToServiceResponse
    {
        public ServiceTimeSlotsDTO TimeSlots { get; set; }

        public InsertReservationToServiceResponse(ServiceTimeSlotsDTO timeSlots)
        {
            TimeSlots = timeSlots;
        }
    }
}
