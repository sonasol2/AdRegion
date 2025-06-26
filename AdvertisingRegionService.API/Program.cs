using AdvertisingRegionService.API.Configurations;

var logger = NLog.LogManager.GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureServices();

    var app = builder.Build();

    app.ConfigureApplication();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, $"Stopped program because of exception: {ex.ToString()}");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
