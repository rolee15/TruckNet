using DTO = TruckNetCore.Application.DTOs;

namespace TruckNetCore.Application.Interfaces;

public interface IGoogleAppSheetsClient
{
    Task<IEnumerable<DTO.Price>> SendPostRequestAsync(string tableName, string requestBody);
}