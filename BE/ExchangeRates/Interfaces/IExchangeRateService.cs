using ExchangeRates.Models;

namespace ExchangeRates.Interfaces;
public interface IExchangeRateService
{
    Task<List<ExchangeRate>> GetCurrencyRatesAsync(bool useDb);
}
