using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

/// <summary>
/// Represents a region entity in the domain layer, encapsulating data from the data access layer.
/// </summary>
public class Region : IRegion
{
    private readonly RegionEntity _regionEntity;
    /// <summary>
    /// Initializes a new instance of the <see cref="Region"/> class with the specified data access layer entity.
    /// </summary>
    public Region(RegionEntity regionEntity)
    {
        _regionEntity = regionEntity;
    }
    
    /// <summary>
    /// Gets the unique identifier of the region entity.
    /// </summary>
    public Guid Id => _regionEntity.Id;
    
    /// <summary>
    /// Gets or sets the name of the region.
    /// </summary>
    public string RegionName 
    { 
        get => _regionEntity.Name;
        set => _regionEntity.Name = value;
    }
}