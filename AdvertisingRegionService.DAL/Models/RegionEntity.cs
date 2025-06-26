using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Models;

public class RegionEntity : IEntity 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}