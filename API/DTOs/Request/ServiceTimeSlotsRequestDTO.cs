namespace API.DTOs.Request
{
    public class ServiceTimeSlotsRequestDTO
    {
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
