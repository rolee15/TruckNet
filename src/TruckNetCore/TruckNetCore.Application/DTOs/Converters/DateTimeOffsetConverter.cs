using System.Text.Json;
using System.Text.Json.Serialization;

namespace TruckNetCore.Application.DTOs.Converters;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String) return reader.GetDateTimeOffset();
        return DateTimeOffset.TryParse(reader.GetString(), out var date) ? date : reader.GetDateTimeOffset();
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("MM/dd/yyyy"));
    }
}