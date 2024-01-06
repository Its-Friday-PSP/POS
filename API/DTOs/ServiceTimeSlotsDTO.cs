namespace API.DTOs
{
    public class ServiceTimeSlotsDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
    }
}
