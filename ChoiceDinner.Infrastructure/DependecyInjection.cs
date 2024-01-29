using ChoiceDinner.Domain.Models.Users;
using ChoiceDinner.Infrastructure.Configurations;
using ChoiceDinner.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ChoiceDinner.Infrastructure;

public static class DependecyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddDbContext<DinnerContext>(options => {
            var efConfig = new EFConfiguration();
            configuration.GetSection(nameof(EFConfiguration)).Bind(efConfig);

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                                action => action.CommandTimeout(efConfig.CommandTimeout));
            options.EnableSensitiveDataLogging(efConfig.EnableSensitiveDataLogging);
            options.EnableDetailedErrors(efConfig.EnableDetailedErrors);
        });

        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<DinnerContext>();


        return services;
    }
}