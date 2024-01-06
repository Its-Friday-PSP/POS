namespace API.DTOs
{
    public class ServiceTimeSlots
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
    }
}
