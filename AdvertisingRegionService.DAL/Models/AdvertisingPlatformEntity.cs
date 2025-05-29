using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Models;

public class AdvertisingPlatformEntity : IEntity
{
    public RegionEntity Region { get; set; }
    public AdvertisingEntity Platforms { get; set; }
    public Guid Id { get; set; }
}