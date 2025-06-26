using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

/// <summary>
/// Represents an advertising platform entity in the domain layer, linking advertising data with a specific region.
/// </summary>
public class AdvertisingPlatform : IAdvertisingPlatform
{
    private readonly AdvertisingPlatformEntity _advertisingPlatform;
    private readonly IAdvertising _advertising;
    private readonly IRegion _region;

    /// <summary>
    /// Initializes a new instance of the <see cref="AdvertisingPlatform"/> class with the specified data access layer entity and associated advertising and region data.
    /// </summary>
    public AdvertisingPlatform(AdvertisingPlatformEntity advertisingPlatform, IAdvertising advertising, IRegion region)
    {
        _advertisingPlatform = advertisingPlatform;
        _advertising = advertising;
        _region = region;
    }

    /// <summary>
    /// Gets the unique identifier of the advertising platform entity.
    /// </summary>
    public Guid Id => _advertisingPlatform.Id; // TODO: Подумать над организацие ID и нужен ли абстрактный класс для этого.
    
    /// <summary>
    /// Gets the advertising entity associated with the platform.
    /// </summary>
    public IAdvertising Advertising => _advertising;
    
    /// <summary>
    /// Gets the region associated with the advertising platform.
    /// </summary>
    public IRegion Region => _region;
    
    
    
}