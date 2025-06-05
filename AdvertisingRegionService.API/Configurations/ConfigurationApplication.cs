using AdvertisingRegionService.API.Middlewares;

namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationApplication
{
    public static void ConfigureApplication(this WebApplication app)
    {
        // app.UseMiddleware<AppMiddlewareException>();
        app.UseExceptionHandler(); 
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapControllers();
    }
}