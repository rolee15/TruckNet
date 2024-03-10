using System.Text.Json;
using Domain.Models;
using TruckNetCore.Application.Interfaces;
using TruckNetCore.Interfaces.Requests;

namespace TruckNetCore.Interfaces.Repositories;

public class PricesRepository : IReadonlyRepository<Price, DateTimeOffset>
{
    private readonly IGoogleAppSheetsClient _googleAppSheetsClient;
    private readonly IMapper _mapper;
    private const string TableName = "prices";

    public PricesRepository(IGoogleAppSheetsClient googleAppSheetsClient, IMapper mapper)
    {
        _googleAppSheetsClient = googleAppSheetsClient;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Price>> GetAllAsync()
    {
        var request = new GoogleAppSheetRequest(action: "Find", properties: new Properties(), rows: Array.Empty<string>());
        var json = JsonSerializer.Serialize(request);
        var pricesDto = await _googleAppSheetsClient.SendPostRequestAsync(TableName, json);
        return _mapper.MapToEntities(pricesDto);
    }

}