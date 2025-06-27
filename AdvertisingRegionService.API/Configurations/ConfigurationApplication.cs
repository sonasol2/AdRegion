
using AdvertisingRegionService.API.Middlewares;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationApplication
{
    public static void ConfigureApplication(this WebApplication app)
    {
        app.UseExceptionHandler(); 
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
        
        app.MapControllers();
    }
}