using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Abstractions;
/// <summary>
/// Interface for working with the cache of data about advertising platforms.
/// </summary>
public interface IAdvertisingPlatformRepository : IRepository<AdvertisingPlatformEntity>
{
    /// <summary>
    /// Clear all advertising platform data cache
    /// </summary>
    void ClearCache();
    /// <summary>
    /// Gets a list advertising platform available for specified location.
    /// Takes into account the hierarchy of regions.
    /// </summary>
    /// <param name="region">Location(region) for which platforms are requested </param>
    /// <returns>Unique advertising platform name</returns>
    HashSet<string> GetAdvertisingPlatformByRegion(string region);
}