using AdvertisingRegionService.Domain;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.DAL.Interfaces;

public interface ICacheRepository : IRepository<AdvertisingPlatform>
{
    void ClearCache();
    HashSet<string> GetAdvertisingPlatformByLocation(string location);
}