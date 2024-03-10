using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TruckNetCore.Application.DTOs.Converters;
using TruckNetCore.Application.Interfaces;
using DTO = TruckNetCore.Application.DTOs;

namespace TruckNetCore.Interfaces.Clients;

public class GoogleAppGoogleAppSheetsClient : IGoogleAppSheetsClient
{
    private readonly HttpClient _httpClient;
    private const string ApiBaseUrl = "https://api.appsheet.com/api/v2/apps";
    private readonly string _appId;

    public GoogleAppGoogleAppSheetsClient(string appId,string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("applicationAccessKey", apiKey);
        _appId = appId;
    }
    
    public async Task<IEnumerable<DTO.Price>> SendPostRequestAsync(string tableName, string requestBody)
    {
        var endpoint = $"{ApiBaseUrl}/{_appId}/tables/{tableName}/Action";
        
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeOffsetConverter());
            options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
            var result = JsonSerializer.Deserialize<IEnumerable<DTO.Price>>(responseContent, options);
            
            if (result is null)
            {
                throw new Exception($"Error getting the result from the POST request: {response.StatusCode}");
            }
            
            return result;
        }

        throw new Exception($"Error sending POST request: {response.StatusCode}");
    }

}