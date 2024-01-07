using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        [Required]
        public Auth Auth { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<ServiceTimeSlots> ServiceTimeSlots { get; set; }
    }
}
