namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IAdvertisingModel
{
    public HashSet<string> AdvertisingName { get; }
    public DateTime PublishDate { get; }
}