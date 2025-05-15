using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Models;


namespace AdvertisingRegionService.Domain.Parsers
{
    public class AdRegionFileParser : IAdRegionFileParser
    {
        public Dictionary<string, List<string>> Parse(string fileContent)
        {
            if (string.IsNullOrEmpty(fileContent))
            {
                return new Dictionary<string, List<string>>();
            }

            var platforms = new Dictionary<string, List<string>>();
            
            foreach (var line in fileContent.Split(Constants.LineSplitter))
            {
                var parts = line.Split(Constants.PartsSplitter);
                if (parts.Length == Constants.MaxAllowedPartsCount)
                {
                    var platform = parts[0].Trim();
                    var region = parts[1].Split(Constants.RegionSplitter).Select(l => l.Trim().TrimEnd()).ToList();
                    
                    foreach (var location in region) 
                    {
                        if (!platforms.ContainsKey(location))
                            platforms[location] = new List<string>();
                        if (!platforms[location].Contains(platform))
                            platforms[location].Add(platform);                
                    }
                } 
            }

            return platforms;
        }

        public List<AdvertisingPlatform> BuildRegionHierarchy(Dictionary<string, List<string>> regionPlatforms)
        {
            var platforms = new List<AdvertisingPlatform>();
            
            foreach (var region in regionPlatforms.Keys)
            {
                var currentRegion = region;
                var platformsForLocation = new List<string>();

                while (!string.IsNullOrEmpty(currentRegion))
                {
                    if(regionPlatforms.ContainsKey(currentRegion))
                        platformsForLocation.AddRange(regionPlatforms[currentRegion]);

                    currentRegion = GetParentLocation(currentRegion);
                }
                
                platforms.Add(new AdvertisingPlatform()
                {
                    Region = region,
                    Platforms = platformsForLocation.Distinct().ToList().ToHashSet()
                });
            }
            
            return platforms;
        }

        private string GetParentLocation(string region)
        {
            var lastIndex = region.LastIndexOf(Constants.LastRegionIndex);
            return lastIndex > 0 ? region.Substring(0, lastIndex) : string.Empty;
        }
    }
}