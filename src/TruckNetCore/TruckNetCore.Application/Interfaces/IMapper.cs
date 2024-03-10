using Domain.Models;

namespace TruckNetCore.Application.Interfaces;

public interface IMapper
{
    IEnumerable<Price> MapToEntities(IEnumerable<Application.DTOs.Price> pricesDto);
}