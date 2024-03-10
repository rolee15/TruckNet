using Domain.Models;
using TruckNetCore.Application.Interfaces;

namespace TruckNetCore.Application.Managers;

public class SheetManager
{
    private readonly IReadonlyRepository<Price, DateTimeOffset> _pricesRepository;

    public SheetManager(IReadonlyRepository<Price, DateTimeOffset> pricesRepository)
    {
        _pricesRepository = pricesRepository;
    }

    public async Task<IEnumerable<Price>> GetAllPricesAsync()
    {
        return await _pricesRepository.GetAllAsync();
    }
}