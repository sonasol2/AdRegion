using AdvertisingRegionService.Domain.Models.Interfaces;
using AdvertisingRegionService.Domain.Services;

namespace AdvertisingRegionService.Domain.Abstractions;

/// <summary>
/// Defines a contract for managing advertising platforms and their association with regions.
/// </summary>
public interface IAdvertisingRegionService
{
    /// <summary>
    /// Asynchronously uploads a file containing advertising platform data.
    /// </summary>
    /// <param name="stream">The stream containing the file data. Must not be null.</param>
    Task<bool> UploadFile(Stream stream);
    HashSet<string> GetPlatformByRegion(string location);
    
    /// <summary>
    /// Searches for advertising platforms based on the specified search predicates.
    /// </summary>
    /// <param name="searchPredicates">A list of parameters defines the search criteria. </param>
    /// <returns>An IReadOnlyCollection of <see cref="IAdvertisingPlatform"/> objects matching the search criteria, or null if no platforms are found.</returns>
    IReadOnlyCollection<IAdvertisingPlatform>? SearchPlatform(List<SearchPredicate>? searchPredicates);
}

