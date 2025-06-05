namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IAdvertising : IDomainModel
{
    public HashSet<string> AdvertisingName { get; }
    public DateTime PublishDate { get; }
}