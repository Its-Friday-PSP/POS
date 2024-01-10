namespace API.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Auth Auth { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<ServiceTimeSlots> ServiceTimeSlots { get; set; }
    }
}
