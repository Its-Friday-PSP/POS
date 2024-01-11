namespace API.Model
{
    public class ServiceTimeSlots
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
        public ServiceTimeSlots(Guid customerId, Guid employeeId, DateTime startTime, DateTime endTime, bool isBooked, Guid? serviceId = null)
        {
            Id = Guid.NewGuid();
            ServiceId = serviceId ?? Guid.Empty;
            CustomerId = customerId;
            EmployeeId = employeeId;
            StartTime = startTime;
            EndTime = endTime;
            IsBooked = isBooked;
        }

        public ServiceTimeSlots()
        {
        }
    }
}
