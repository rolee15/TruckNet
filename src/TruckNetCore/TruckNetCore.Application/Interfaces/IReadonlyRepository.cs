using Domain.Models;

namespace TruckNetCore.Application.Interfaces;

public interface IReadonlyRepository<T, in TId> where T : EntityBase<TId>
{
    Task<IEnumerable<T>> GetAllAsync();
}