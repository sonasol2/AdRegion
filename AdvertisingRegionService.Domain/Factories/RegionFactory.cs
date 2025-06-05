using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public class RegionFactory : BaseDomainFactory<IRegion, RegionEntity>, IRegionFactory
{
    public RegionFactory(IRegionRepository repository) : base(repository)
    {
    }

    public override IRegion Create(RegionEntity entity)
    {
        return new Region(entity);
    }
}