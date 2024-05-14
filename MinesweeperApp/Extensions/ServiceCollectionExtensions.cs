using Microsoft.Extensions.DependencyInjection;
using MinesweeperApp.Services;
using MinesweeperApp.Services.Interfaces;

namespace MinesweeperApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        return services;
    }
}
