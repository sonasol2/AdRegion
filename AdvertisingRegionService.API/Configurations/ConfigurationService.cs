using AdvertisingRegionService.API.Middlewares;
using AdvertisingRegionService.DAL;
using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Repositories;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Factories;
using AdvertisingRegionService.Domain.Parsers;
using AdvertisingRegionService.Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationService
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        services.AddSingleton(typeof(CacheContext<>));
        
        services.AddSwaggerGen();

        AddBusinessServices(services);
        AddControllersConfiguration(services);
        AddValidators(services);
        AddRepositories(services);        
        AddFactories(services);
    }
    

    private static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddSingleton<IAdvertisingRegionService, Domain.Services.AdvertisingRegionService>();
        services.AddSingleton<IAdvertisingRegionFileParser, AdvertisingRegionFileParser>();
        services.AddSingleton<IDateTimeHelper, DateTimeHelper>();
    }

    private static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly); //TODO: Обговорить автоматическую валидацию в контроллерах и как реализовать
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }
    
    private static void AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAdvertisingPlatformRepository, AdvertisingPlatformRepository>();
        services.AddSingleton<IRegionRepository, RegionRepository>();
        services.AddSingleton<IAdvertisingRepository, AdvertisingRepository>();
    }

    private static void AddFactories(this IServiceCollection services)
    {
        services.AddSingleton<IRegionFactory, RegionFactory>();
        services.AddSingleton<IAdvertisingFactory, AdvertisingFactory>();
        services.AddSingleton<IAdvertisingPlatformFactory, AdvertisingPlatformFactory>();
    }
}