using API.Enumerators;

namespace API.Model
{
    public class Tip
    {
        public Price Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public TipType TipType { get; set; }
    }
}
