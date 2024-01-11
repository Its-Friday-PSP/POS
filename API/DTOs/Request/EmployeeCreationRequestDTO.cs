using API.Model;

namespace API.DTOs.Request
{
    public class EmployeeCreationRequestDTO
    {
        public Auth Auth { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<EmployeeServiceTimeSlotsRequestDTO>? ServiceTimeSlots { get; set; }
    }
}
