using Asp.Versioning;
using ExchangeRates.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRates.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ExchangeRatesController(IExchangeRateService exchangeRateService) : ControllerBase
{
    [MapToApiVersion("1.0")]
    [Route("Get")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] bool useDb)
    {
        var resp = await exchangeRateService.GetCurrencyRatesAsync(useDb);

        return Ok(resp);
    }
}
