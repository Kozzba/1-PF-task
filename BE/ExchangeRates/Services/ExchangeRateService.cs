using System.Text.Json;
using ExchangeRates.Data;
using ExchangeRates.Interfaces;
using ExchangeRates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExchangeRates.Services;

public class ExchangeRateService(IOptions<CeskaSporitelnaOption> options,
    ILogger<ExchangeRateService> logger,
    ApplicationDbContext dbContext) : IExchangeRateService
{
    public async Task<List<ExchangeRate>> GetCurrencyRatesAsync(bool useDb)
    {
        if (useDb == false)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(options.Value.Url);

            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();

            logger.LogDebug($"responseData {responseData}");

            var ceskaSporitelnaResponse = JsonSerializer.Deserialize<List<ExchangeRate>>(responseData);

            if (ceskaSporitelnaResponse == null)
                throw new Exception($"{nameof(ceskaSporitelnaResponse)} is null");

            foreach (var exchangeRate in ceskaSporitelnaResponse)
            {
                var exchangeRateDb = await dbContext.ExchangeRateSet.FirstOrDefaultAsync(x => x.ShortName == exchangeRate.ShortName);

                if (exchangeRateDb != null)
                {
                    MapExchangeRate(exchangeRateDb, exchangeRate);
                }
                else
                {
                    await dbContext.ExchangeRateSet.AddAsync(exchangeRate);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        return await dbContext.ExchangeRateSet.ToListAsync(); 
    }

    private void MapExchangeRate(ExchangeRate exchangeRateDb, ExchangeRate exchangeRate)
    {
        exchangeRateDb.Amount = exchangeRate.Amount;
        exchangeRateDb.CnbMid = exchangeRate.CnbMid;
        exchangeRateDb.ValidFrom = exchangeRate.ValidFrom;
        exchangeRateDb.Name = exchangeRate.Name;
        exchangeRateDb.Country = exchangeRate.Country;
        exchangeRateDb.Move = exchangeRate.Move;
        exchangeRateDb.Amount = exchangeRate.Amount;
        exchangeRateDb.ValBuy = exchangeRate.ValBuy;
        exchangeRateDb.ValSell = exchangeRate.ValSell;
        exchangeRateDb.ValMid = exchangeRate.ValMid;
        exchangeRateDb.CurrBuy = exchangeRate.CurrBuy;
        exchangeRateDb.CurrSell = exchangeRate.CurrSell;
        exchangeRateDb.CurrMid = exchangeRate.CurrMid;
        exchangeRateDb.Version = exchangeRate.Version;
        exchangeRateDb.CnbMid = exchangeRate.CnbMid;
        exchangeRateDb.EcbMid = exchangeRate.EcbMid;
    }
}
