using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Constants;
using AdvertisingRegionService.Domain.Factories;

namespace AdvertisingRegionService.Domain.Parsers;

public class AdvertisingRegionFileParser : IAdvertisingRegionFileParser
{
    
    private readonly IAdvertisingPlatformFactory _advertisingPlatformFactory;
    private readonly IAdvertisingFactory _advertisingFactory;
    private readonly IRegionFactory _regionFactory;
    private readonly IDateTimeHelper _dateTimeHelper;
    public AdvertisingRegionFileParser(IAdvertisingPlatformFactory advertisingPlatformFactory, IDateTimeHelper dateTimeHelper)
    {
        _advertisingPlatformFactory = advertisingPlatformFactory;
        _dateTimeHelper = dateTimeHelper;
    }

    public IReadOnlyCollection<AdvertisingPlatformEntity> Parse(string fileContent)
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
                platforms[location] = [];
            if (!platforms[location].Contains(platform))
                platforms[location].Add(platform);
        }
    }

    private List<AdvertisingPlatformEntity> BuildRegionHierarchy(Dictionary<string, HashSet<string>> regionPlatforms)
    {
        var platforms = new List<AdvertisingPlatformEntity>();
        
        foreach (var region in regionPlatforms.Keys)
        {
            platforms.Add(new AdvertisingPlatformEntity
            {
                Region = new RegionEntity() {Name = region},
                Platform = new AdvertisingEntity() {
                    PlatformNames = GetPlatformsForRegionHierarchy(region, regionPlatforms), 
                    PostedAt = _dateTimeHelper.UtcNow,
                } 
            });
        }
        
        return platforms;
    }
    
    private HashSet<string> GetPlatformsForRegionHierarchy(string region, Dictionary<string, HashSet<string>> regionPlatforms)
    {
        var currentRegion = region;
        HashSet<string> platformsForLocation = [];
        
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
