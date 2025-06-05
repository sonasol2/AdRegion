namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IAdvertisingPlatform : IDomainModel
{
    IAdvertising Advertising { get; }
    IRegion Region { get; }
}