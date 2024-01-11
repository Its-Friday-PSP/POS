namespace API.DTOs.Request
{
    public class EmployeeServiceTimeSlotsRequestDTO
    {
        public Guid ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
