using API.DTOs;

namespace API.Responses.Reservation
{
    public class GetReservationsRespone
    {
        public List<ServiceTimeSlotsDTO> Reservations { get; set; }

        public GetReservationsRespone(List<ServiceTimeSlotsDTO> reservations)
        {
            Reservations = reservations;
        }
    }
}
