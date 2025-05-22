using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Constants;
using AdvertisingRegionService.Domain.Interfaces;

namespace AdvertisingRegionService.Domain.Parsers;

public class AdvertisingRegionFileParser : IAdvertisingRegionFileParser
{
    public List<AdvertisingPlatform> Parse(string fileContent)
    {
        
        var platformsDictionary = new Dictionary<string, HashSet<string>>();
        
        foreach (var line in fileContent.Split(ParserConstants.LineSplitter))
        {
            var parts = line.Split(ParserConstants.PartsSplitter);
            if (parts.Length == ParserConstants.MaxAllowedPartsCount)
            {
                var platform = parts[0].Trim();
                var regions = parts[1].Split(ParserConstants.RegionSplitter).Select(l => l.Trim().TrimEnd()).ToHashSet();
                
                AddPlatformToRegions(platform, regions, platformsDictionary);
            } 
        }

        return BuildRegionHierarchy(platformsDictionary);
    }
    
    private void AddPlatformToRegions(string platform, HashSet<string> regions, Dictionary<string, HashSet<string>> platforms)
    {
        foreach (var location in regions)
        {
            if (!platforms.ContainsKey(location))
                platforms[location] = new HashSet<string>();
            if (!platforms[location].Contains(platform))
                platforms[location].Add(platform);
        }
    }

    private List<AdvertisingPlatform> BuildRegionHierarchy(Dictionary<string, HashSet<string>> regionPlatforms)
    {
        var platforms = new List<AdvertisingPlatform>();
        
        foreach (var region in regionPlatforms.Keys)
        {
            platforms.Add(new AdvertisingPlatform
            {
                Region = region,
                Platforms = GetPlatformsForRegionHierarchy(region, regionPlatforms)
            });
        }
        
        return platforms;
    }
    
    private HashSet<string> GetPlatformsForRegionHierarchy(string region, Dictionary<string, HashSet<string>> regionPlatforms)
    {
        var currentRegion = region;
        var platformsForLocation = new HashSet<string>();
        
        while (!string.IsNullOrEmpty(currentRegion))
        {
            if (regionPlatforms.ContainsKey(currentRegion))
                platformsForLocation.UnionWith(regionPlatforms[currentRegion]);

            currentRegion = GetParentLocation(currentRegion);
        }

        return platformsForLocation;
    }
    
    private string GetParentLocation(string region)
    {
        var lastIndex = region.LastIndexOf(ParserConstants.LastRegionIndex);
        return lastIndex > 0 ? region.Substring(0, lastIndex) : string.Empty;
    }
}
