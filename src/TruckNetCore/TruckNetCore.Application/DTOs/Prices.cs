using System.Text.Json.Serialization;

namespace TruckNetCore.Application.DTOs;
public class Price
{
    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; }
    [JsonPropertyName("mol")]
    public decimal MolPrice { get; set;  }
    [JsonPropertyName("uih")]
    public decimal UihPrice { get; set; }
    
}