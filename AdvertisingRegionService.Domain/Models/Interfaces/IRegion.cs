namespace AdvertisingRegionService.Domain.Models.Interfaces;

/// <summary>
/// Defines a contract for a region entity in the domain layer.
/// </summary>
public interface IRegion : IDomainModel
{
    /// <summary>
    /// Gets the name of the region.
    /// </summary>
    public string RegionName { get; }
}