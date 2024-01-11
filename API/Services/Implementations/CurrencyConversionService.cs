using API.Enumerators;
using API.Services.Interfaces;
using API.Shared;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace API.Services.Implementations
{

    public class CurrencyConversionService : ICurrencyConversionService
    {
        public async Task<long> GetConversionRate(Currency fromCurrency, Currency toCurrency)
        {
            var requestString = $@"https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_m2EeWSd6DDpzKMCAQsXC6pBlBVSnyXZRTs3zNgMd&currencies={fromCurrency}&base_currency={toCurrency}";
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromDays(1) };

            var response = await client.GetAsync(requestString);

            if((int) response.StatusCode != 200)
            {
                throw new ArgumentException($"{fromCurrency} {toCurrency}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var conversion = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, decimal>>>(responseBody)!;
            
            if(conversion?.Count > 0)
            {
                return (long) (conversion.First().Value.First().Value * (decimal) Constants.DECIMAL_MULTIPLIER);
            }

            throw new ArgumentException("Could not convert value");
        }
    }
}
