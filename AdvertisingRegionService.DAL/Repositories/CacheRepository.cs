using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class CacheRepository: ICacheRepository
{
    private readonly CacheContext _cacheContext;

    public CacheRepository(CacheContext cacheContext)
    {
        _cacheContext = cacheContext;
    }

    public ICollection<AdvertisingPlatform> GetAll()
    { 
        return _cacheContext.AdvertisingPlatform.ToList();
    }

    public AdvertisingPlatform GetById(Guid id)
    {
        return _cacheContext.AdvertisingPlatform.FirstOrDefault(ap => ap.Id == id)!;
    }

    public void Add(AdvertisingPlatform advertisingPlatform)
    {
        _cacheContext.AdvertisingPlatform.Add(advertisingPlatform);
    }

    public void AddRange(ICollection<AdvertisingPlatform> advertisingPlatforms)
    {
        if (_cacheContext.AdvertisingPlatform is List<AdvertisingPlatform> cacheContext)
        {
            cacheContext.AddRange(advertisingPlatforms);
        }
        else
        {
            foreach (var advertisingPlatform in advertisingPlatforms)
            {
                _cacheContext.AdvertisingPlatform.Add(advertisingPlatform);
            }
        }
   
    }
    
    public void RemoveEntity(AdvertisingPlatform advertisingPlatform)
    {
        _cacheContext.AdvertisingPlatform.Remove(advertisingPlatform);
    }

    public void ClearCache()
    {
        _cacheContext.AdvertisingPlatform.Clear();
    }

    public HashSet<string> GetAdvertisingPlatformByLocation(string location)
    {
        return _cacheContext.AdvertisingPlatform
            .FirstOrDefault(ap => ap.Region.Contains(location))!
            .Platforms;
    }
}