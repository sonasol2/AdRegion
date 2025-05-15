using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.DAL;

public class CacheContext
{
    public ICollection<AdvertisingPlatform> AdvertisingPlatform { get; set; } = new List<AdvertisingPlatform>();
}
    