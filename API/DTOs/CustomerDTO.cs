using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CustomerDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public AuthDTO? Auth { get; set; }
    }
}
