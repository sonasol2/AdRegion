using AdvertisingRegionService.DAL.Interfaces;

namespace AdvertisingRegionService.DAL.Models;

public class AdvertisingPlatform : IEntity
{
    public string Region { get; set; }
    public HashSet<string> Platforms { get; set; } //TODO: подумать над тем какую коллекцию использовать
    public Guid Id { get; set; }
}