using API.Model;

namespace API.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public Auth Auth { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
