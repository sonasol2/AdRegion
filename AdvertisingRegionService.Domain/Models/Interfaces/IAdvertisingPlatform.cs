namespace AdvertisingRegionService.Domain.Models.Interfaces;

/// <summary>
/// Defines a contract for an advertising platform entity that associates advertising data with a specific region.
/// </summary>
public interface IAdvertisingPlatform : IDomainModel
{
    /// <summary>
    /// Gets the advertising entity associated with the platform.
    /// </summary>
    IAdvertising Advertising { get; }
    
    /// <summary>
    /// Gets the region associated with the advertising platform.
    /// </summary>
    IRegion Region { get; }
}