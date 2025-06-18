using AdvertisingRegionService.Domain.Abstractions;

namespace AdvertisingRegionService.Domain.Services;

public class DateTimeHelper : IDateTimeHelper
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}