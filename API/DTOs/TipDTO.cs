using API.Enumerators;
using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class TipDTO
    {
        [Required]
        public Price Price { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public TipType TipType { get; set; }
    }
}
