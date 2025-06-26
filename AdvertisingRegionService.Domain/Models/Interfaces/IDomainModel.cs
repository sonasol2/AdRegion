namespace AdvertisingRegionService.Domain.Models.Interfaces;

/// <summary>
/// Defines a contract for domain models, providing a unique identifier.
/// </summary>
public interface IDomainModel
{
    /// <summary>
    /// Gets the unique identifier of the domain model.
    /// </summary>
    public Guid Id { get; }
}