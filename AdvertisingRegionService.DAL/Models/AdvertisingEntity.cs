using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Models;

public class AdvertisingEntity : IEntity
{
    public DateTime PostedAt {get;set;}
    public HashSet<string> PlatformsName { get; set; }
    public Guid Id { get; set; }
}