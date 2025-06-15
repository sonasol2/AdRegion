using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

/// <summary>
/// Represents an advertising entity in the domain layer, encapsulating data from the data access layer.
/// </summary>
public class Advertising : IAdvertising
{
    private readonly AdvertisingEntity _advertisingEntity;

    /// <summary>
    /// Initializes a new instance of the <see cref="Advertising"/> class with the specified data access layer entity.
    /// </summary>
    public Advertising(AdvertisingEntity advertisingEntity)
    {
        _advertisingEntity = advertisingEntity;
    }

    /// <summary>
    /// Gets the unique identifier of the advertising entity.
    /// </summary>
    public Guid Id => _advertisingEntity.Id;
    
    /// <summary>
    /// Gets or sets the collection of unique names or identifiers of advertising platforms associated with the entity.
    /// </summary>
    public HashSet<string> AdvertisingName
    {
        get => _advertisingEntity.PlatformNames;
        set =>  _advertisingEntity.PlatformNames = value;}

    /// <summary>
    /// Gets or sets the date and time when the advertising entity was published.
    /// </summary>
    public DateTime PublishDate
    {
        get => _advertisingEntity.PostedAt;
        set => _advertisingEntity.PostedAt = value;
    }
}