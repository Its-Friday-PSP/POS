using API.DTOs;
namespace API.Requests.Reservation
{
    public class InsertReservationToEmployeeResponse
    {
        public ServiceTimeSlotsDTO TimeSlots { get; set; }

        public InsertReservationToEmployeeResponse(ServiceTimeSlotsDTO timeSlots)
        {
            TimeSlots = timeSlots;
        }
    }
}
