using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public class AdvertisingPlatformFactory : BaseDomainFactory<IAdvertisingPlatform, AdvertisingPlatformEntity>, IAdvertisingPlatformFactory
{
    private readonly IRegionFactory _regionFactory;
    private readonly IAdvertisingFactory _advertisingFactory;
    private readonly IAdvertisingPlatformRepository _advertisingPlatformRepository;
    
    public AdvertisingPlatformFactory(IAdvertisingPlatformRepository repository, IRegionFactory regionFactory, IAdvertisingFactory advertisingFactory) : base(repository)
    {
        _regionFactory = regionFactory;
        _advertisingFactory = advertisingFactory;
        _advertisingPlatformRepository = repository;
    }

    public override IAdvertisingPlatform Create(AdvertisingPlatformEntity entity)
    {
        var region = _regionFactory.Create(entity.Region);
        var advertising = _advertisingFactory.Create(entity.Platform);
        
        return new AdvertisingPlatform(entity, advertising, region);
    }

    public override IEnumerable<IAdvertisingPlatform> CreateAll(IEnumerable<AdvertisingPlatformEntity> entities)
    {
        var platforms = new List<IAdvertisingPlatform>();
        
        foreach (var entity in entities)
        {
            var region = _regionFactory.Create(entity.Region);
            var advertising = _advertisingFactory.Create(entity.Platform);
            
            var platform = new AdvertisingPlatform(entity, advertising, region);
            platforms.Add(platform);
        }
        return platforms;
    }
}