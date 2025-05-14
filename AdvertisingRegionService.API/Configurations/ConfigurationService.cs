using AdvertisingRegionService.API.Services;
using AdvertisingRegionService.API.Services.Interfaces;
using AdvertisingRegionService.API.Validators;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Parsers;
using FluentValidation;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationService
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        
        return services
            .AddValidators()
            .AddBusinessServices()
            .AddControllersConfiguration();
    }
    

    private static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAdRegionService, AdRegionService>();
        services.AddSingleton<IAdRegionFileParser, AdRegionFileParser>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.AddTransient<IValidatorService, ValidatorService>();
        
        return services;
    }
    
    private static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}