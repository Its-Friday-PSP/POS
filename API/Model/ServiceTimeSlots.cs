namespace API.Model
{
    public class ServiceTimeSlots
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }

        public ServiceTimeSlots(DateTime startTime, DateTime endTime, bool isBooked)
        {
            StartTime = startTime;
            EndTime = endTime;
            IsBooked = isBooked;
        }
    }
}
