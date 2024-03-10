using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace TruckNetCore.Interfaces.Requests;

internal struct GoogleAppSheetRequest
{
    public string Action { get; }
    public Properties Properties { get; }
    public string[]? Rows { get; }
    
    [JsonConstructor]
    public GoogleAppSheetRequest(string action, Properties properties, string[]? rows)
    {
        Action = action;
        Properties = properties;
        Rows = rows;
    }
}

[UsedImplicitly]
internal struct Properties
{
    [JsonConstructor]
    public Properties(string? selector)
    {
    }
}