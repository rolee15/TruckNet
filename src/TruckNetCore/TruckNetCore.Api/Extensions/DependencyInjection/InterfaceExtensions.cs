using Domain.Models;
using TruckNetCore.Application.Interfaces;
using TruckNetCore.Interfaces.Clients;
using TruckNetCore.Interfaces.Repositories;

// ReSharper disable StringLiteralTypo

namespace TruckNetCore.Api.Extensions.DependencyInjection;

internal static class InterfaceExtensions
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IReadonlyRepository<Price, DateTimeOffset>, PricesRepository>();
        services.AddTransient<IGoogleAppSheetsClient>(_ =>
        {
            const string appId = "931da275-b7f9-4641-b112-ba34d73ddbd6";
            const string apiKey = "V2-5ZJMe-gU6lj-af61f-Ktcr0-O2JFc-8bYbX-YgzZV-3VGIN";
            return new GoogleAppGoogleAppSheetsClient(appId, apiKey);
        });
        return services;
    }
}