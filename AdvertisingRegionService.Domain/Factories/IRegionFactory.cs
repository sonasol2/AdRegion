using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public interface IRegionFactory : IDomainFactory<IRegion, RegionEntity>
{
}