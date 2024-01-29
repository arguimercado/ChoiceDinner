using ChoiceDinner.Application.Features.Authentications.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ChoiceDinner.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Register.Handler).Assembly));
        

        return services;
    }
}

internal class DinnerContext
{
}