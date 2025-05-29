using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class AdvertisingPlatformRepository : Repository<AdvertisingPlatformEntity>, IAdvertisingPlatformRepository
{
    private readonly CacheContext _cacheContext;

    public AdvertisingPlatformRepository(CacheContext cacheContext)
    {
        _cacheContext = cacheContext;
    }

    public override IQueryable<AdvertisingPlatformEntity> GetAll()
    { 
        return _cacheContext.AdvertisingPlatform.AsQueryable();
    }

    public override AdvertisingPlatformEntity GetById(Guid id)
    {
        return _cacheContext.AdvertisingPlatform.FirstOrDefault(ap => ap.Id == id)!;
    }

    public override void Add(AdvertisingPlatformEntity advertisingPlatformEntity)
    {
        _cacheContext.AdvertisingPlatform.Add(advertisingPlatformEntity);
    }

    public override void AddRange(IEnumerable<AdvertisingPlatformEntity> advertisingPlatforms)
    {
            foreach (var advertisingPlatform in advertisingPlatforms)
            {
                _cacheContext.AdvertisingPlatform.Add(advertisingPlatform);
            }
    }

    public override void Update(AdvertisingPlatformEntity entity)
    {
        var existingEntity = GetById(entity.Id);
        if (existingEntity != null)
        {
            existingEntity.Region = entity.Region;
            existingEntity.Platforms = entity.Platforms;
        }
    }
    public override void Remove(AdvertisingPlatformEntity advertisingPlatformEntity)
    {
        _cacheContext.AdvertisingPlatform.Remove(advertisingPlatformEntity);
    }

    public void ClearCache()
    {
        _cacheContext.AdvertisingPlatform.Clear();
    }

    public HashSet<string> GetAdvertisingPlatformByLocation(string location)
    {
        return _cacheContext.AdvertisingPlatform
            .FirstOrDefault(ap => ap.Region.Name.Contains(location))!
            .Platforms.PlatformsName;
    }
}