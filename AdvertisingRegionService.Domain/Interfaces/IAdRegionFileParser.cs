using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Interfaces;

public interface IAdRegionFileParser
{
    Dictionary<string, List<string>> Parse(string fileContents);
    List<AdvertisingPlatform> BuildRegionHierarchy(Dictionary<string, List<string>> regionPlatforms);

}