using AdvertisingRegionService.API.Models.Responses;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.API.Services;

public static class Mapper
{
    public static SearchResponse MapSearchResponse(IEnumerable<IAdvertisingPlatform> advertisingPlatforms)
    {
        SearchResponse searchResponse = new SearchResponse
        {
            PlatformName = advertisingPlatforms.SelectMany(platform => platform.Advertising.AdvertisingName)
                .Distinct()
                .ToList(),
            RegionName = advertisingPlatforms.Select(region => region.Region.RegionName)
                .Distinct()
                .ToList()
        };
        return searchResponse;
    }
}