using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.DAL.Repositories;
using AdvertisingRegionService.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingRegionService.DAL.Configurations;

public static class ConfigurationDALService
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<AdvertisingPlatform>, CacheRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();
        
        return services;
    }
}