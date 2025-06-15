using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.Domain.Abstractions;

/// <summary>
/// Defines a contract for parsing text file content into a collection of advertising platform entities.
/// </summary>
public interface IAdvertisingRegionFileParser
{
    /// <summary>
    /// Parse the provided text file content into of advertising platform entities
    /// </summary>
    /// <param name="fileContents">The content of the text file as a string.</param>
    /// <returns>A list of advertising platform</returns>
    List<AdvertisingPlatformEntity> Parse(string fileContents);

}