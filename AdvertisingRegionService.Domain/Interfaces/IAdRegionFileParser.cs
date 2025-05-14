namespace AdvertisingRegionService.Domain.Interfaces;

public interface IAdRegionFileParser
{
    Dictionary<string, List<string>> Parse(string fileContents);
    Dictionary<string, List<string>> BuildRegionHierarchy(Dictionary<string, List<string>> regionPlatforms);
    string GetParentLocation(string region);

}