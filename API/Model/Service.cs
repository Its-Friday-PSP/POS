namespace API.Model
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }
        public List<ServiceTimeSlots>? ServiceTimeSlots { get; set; }
    }
}
