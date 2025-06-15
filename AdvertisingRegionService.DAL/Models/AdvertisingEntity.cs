using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Models;

/// <summary>
/// Represents an advertising entity in the data access layer, containing data about advertising platforms and publication details.
/// </summary>
public class AdvertisingEntity : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the advertising entity.
    /// </summary>
     public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the advertising entity was published.
    /// </summary>
    public DateTime PostedAt {get;set;}
    
    /// <summary>
    /// Gets or sets the collection of unique names or identifiers of advertising platforms associated with the entity.
    /// </summary>
    public HashSet<string> PlatformNames { get; set; }
}