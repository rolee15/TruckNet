using Domain.Models;
using TruckNetCore.Application.Interfaces;

namespace TruckNetCore.Application.Mappers;

public class Mapper : IMapper
{
    public IEnumerable<Price> MapToEntities(IEnumerable<Application.DTOs.Price> pricesDto)
    {
        return pricesDto.Select(price => new Price(price.Date, price.MolPrice, price.UihPrice));
    }
}