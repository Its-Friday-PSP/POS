using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Order
    {
        [Required]
        public Guid? Id { get; set; }

    }
}
