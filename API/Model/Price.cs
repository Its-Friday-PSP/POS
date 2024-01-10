using API.Enumerators;

namespace API.Model
{
    public class Price
    {
        public long Amount { get; set; }
        public Currency Currency { get; set; }

        public Price() { }

        public  Price(long amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
