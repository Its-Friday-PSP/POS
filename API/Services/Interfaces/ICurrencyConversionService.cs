using API.Enumerators;

namespace API.Services.Interfaces
{
    public interface ICurrencyConversionService
    {
        public Task<long> GetConversionRate(Currency fromCurrency, Currency toCurrency);
    }
}
