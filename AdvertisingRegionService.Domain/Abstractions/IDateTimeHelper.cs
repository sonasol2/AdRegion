namespace AdvertisingRegionService.Domain.Abstractions;

/// <summary>
/// Provide methods for working with dates and times  
/// </summary>
public interface IDateTimeHelper
{ 
    /// <summary>
    /// Gets the current date and time in the system's local time zone.
    /// </summary>
    DateTime Now { get; }
    
    /// <summary>
    /// Gets the current date and time in UTC format
    /// </summary>
    DateTime UtcNow { get; }
}