namespace AdvertisingRegionService.DAL.Abstractions;

/// <summary>
/// Defines a contract for data access layer entities, providing a unique identifier.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    Guid Id { get; set; }
}