using TruckNetCore.Application.Managers;

namespace TruckNetCore.Api.Extensions;

internal static class EndpointExtensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        app.MapGet("/sheets", async (SheetManager manager) => await manager.GetAllPricesAsync());
        
        return app;
    }
}