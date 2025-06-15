using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Models;

/// <summary>
/// Represents an advertising platform entity in the data access layer, linking advertising data with a specific region.
/// </summary>
public class AdvertisingPlatformEntity : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the advertising platform entity.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the region associated with the advertising platform.
    /// </summary>
    public RegionEntity? Region { get; set; }
    
    /// <summary>
    /// Gets or sets the advertising entity associated with the platform.
    /// </summary>
    public AdvertisingEntity? Platform { get; set; }
}