using AdvertisingRegionService.API.Interfaces;
using AdvertisingRegionService.API.Validators;
using AdvertisingRegionService.DAL;
using AdvertisingRegionService.DAL.Configurations;
using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.DAL.Repositories;
using AdvertisingRegionService.Domain;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Parsers;
using AdvertisingRegionService.Domain.Services;
using FluentValidation;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationService
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSingleton<CacheContext>();
        
        services.AddSwaggerGen();
        
        return services
            .AddValidators()
            .AddBusinessServices()
            .AddRepositories()
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