namespace API.DTOs.Request
{
    public class ServiceServiceTimeSlotsCreationRequestDTO
    {
        public Guid? EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
