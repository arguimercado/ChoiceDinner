using ChoiceDinner.Domain.Models.Users;
using ChoiceDinner.Infrastructure.Configurations;
using ChoiceDinner.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace ChoiceDinner.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DinnerContext>(options =>
        {
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

    public static IServiceCollection AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetValue<string>("TokenKey") ?? "secret tokent"));
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
        return services;
    }
}