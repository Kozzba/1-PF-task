using System.Text.Json.Serialization;

namespace ExchangeRates.Models;

public class ExchangeRate
{
    public int Id { get; set; }
    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }
    [JsonPropertyName("validFrom")]
    public DateTime ValidFrom { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("move")]
    public double Move { get; set; }
    [JsonPropertyName("amount")]
    public int Amount { get; set; }
    [JsonPropertyName("valBuy")]
    public double ValBuy { get; set; }
    [JsonPropertyName("valSell")]
    public double ValSell { get; set; }
    [JsonPropertyName("valMid")]
    public double ValMid { get; set; }
    [JsonPropertyName("currBuy")]
    public double CurrBuy { get; set; }
    [JsonPropertyName("currSell")]
    public double CurrSell { get; set; }
    [JsonPropertyName("currMid")]
    public double CurrMid { get; set; }
    [JsonPropertyName("version")]
    public int Version { get; set; }
    [JsonPropertyName("cnbMid")]
    public double CnbMid { get; set; }
    [JsonPropertyName("ecbMid")]
    public double EcbMid { get; set; }
}