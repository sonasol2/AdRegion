namespace AdvertisingRegionService.Domain.Models.Interfaces;

/// <summary>
/// Defines a contract for representing an advertising entity in the domain layer.
/// </summary>
public interface IAdvertising : IDomainModel
{
    /// <summary>
    /// Gets or sets the collection of unique names or identifiers of advertising platforms associated with the entity.
    /// </summary>
    public HashSet<string> AdvertisingName { get; }  //возможно стоит переименовать в PlatformNames?
    
    /// <summary>
    /// Gets or sets the date and time when the advertising entity was published.
    /// </summary>
    public DateTime PublishDate { get; } 
}