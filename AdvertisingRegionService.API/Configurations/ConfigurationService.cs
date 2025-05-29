using AdvertisingRegionService.API.Interfaces;
using AdvertisingRegionService.API.Validators;
using AdvertisingRegionService.DAL;
using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.DAL.Repositories;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Parsers;
using FluentValidation;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationService
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSingleton<CacheContext>();
        
        services.AddSwaggerGen();
        
        AddBusinessServices(services);
        AddControllersConfiguration(services);
        AddValidators(services);
        AddRepositories(services);
    }
    

    private static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAdvertisingRegionService, Domain.Services.AdvertisingRegionService>();
        services.AddSingleton<IAdvertisingRegionFileParser, AdvertisingRegionFileParser>();
    }

    private static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly); //TODO: Обговорить автоматическую валидацию в контроллерах и как реализовать
        services.AddTransient<IValidatorService, ValidatorService>();
    }
    
    private static void AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<AdvertisingPlatform>, CacheRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();
    }
}