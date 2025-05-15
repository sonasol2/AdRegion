using AdvertisingRegionService.Domain.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class AdvertisingPlatform : IEntity
{
    public string Region { get; set; }
    public HashSet<string> Platforms { get; set; } // подумать над тем какую коллекцию использовать
    public Guid Id { get; set; }
}