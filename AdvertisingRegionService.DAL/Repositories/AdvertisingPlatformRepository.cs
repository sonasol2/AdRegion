using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class AdvertisingPlatformRepository : Repository<AdvertisingPlatformEntity>, IAdvertisingPlatformRepository
{
    private readonly CacheContext<AdvertisingPlatformEntity> _cacheContext;

    public AdvertisingPlatformRepository(CacheContext<AdvertisingPlatformEntity> cacheContext) : base(cacheContext)
    {
        _cacheContext = cacheContext;
    }

    public override AdvertisingPlatformEntity GetById(Guid id)
    {
        return _cacheContext.AdvertisingPlatform.FirstOrDefault(ap => ap.Id == id)!;
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
    
    public void ClearCache()
    {
        _cacheContext.AdvertisingPlatform.Clear();
    }

    public HashSet<string> GetAdvertisingPlatformByRegion(string region)
    {
        return _cacheContext.AdvertisingPlatform
            .FirstOrDefault(ap => ap.Region.Name.Contains(region))!
            .Platforms.PlatformsName;
    }
}