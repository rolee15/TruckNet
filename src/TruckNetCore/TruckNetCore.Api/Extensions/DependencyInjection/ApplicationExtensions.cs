using TruckNetCore.Application.Interfaces;
using TruckNetCore.Application.Managers;
using TruckNetCore.Application.Mappers;

namespace TruckNetCore.Api.Extensions.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IMapper, Mapper>();
        services.AddTransient<SheetManager>();
        return services;
    }
}