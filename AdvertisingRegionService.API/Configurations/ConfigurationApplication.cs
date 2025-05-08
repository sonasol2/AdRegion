namespace AdvertisingRegionService.API.Configurations;

public static class ConfigurationApplication
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        
        return app;
    }

}