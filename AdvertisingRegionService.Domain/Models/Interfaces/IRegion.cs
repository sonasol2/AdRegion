namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IRegion : IDomainModel
{
    public string RegionName { get; }
}