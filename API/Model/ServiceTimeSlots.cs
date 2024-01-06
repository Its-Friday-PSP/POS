namespace API.Model
{
    public class ServiceTimeSlots
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
        public Guid ServiceId { get; set; }

        public ServiceTimeSlots(Guid id, Guid customerId, DateTime startTime, DateTime endTime, bool isBooked)
        {
            Id = id;
            CustomerId = customerId;
            StartTime = startTime;
            EndTime = endTime;
            IsBooked = isBooked;
        }
    }
}
