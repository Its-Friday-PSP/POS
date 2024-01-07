using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Auth Auth { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public List<ServiceTimeSlots> ServiceTimeSlots { get; set; }
    }
}
