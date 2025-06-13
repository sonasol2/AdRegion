using AdvertisingRegionService.API.Models.Requests;
using AdvertisingRegionService.Domain.Services;

namespace AdvertisingRegionService.API.Services;

public class PredicateSearchFactory
{
    public static List<SearchPredicate> CreateSearchPredicates(SearchRequest searchRequest) // вынес сюда чтобы сделать контроллер чище
    {
        var searchPredicates = new List<SearchPredicate>();

        if (!string.IsNullOrEmpty(searchRequest.SearchText)) 
            searchPredicates.Add(platform =>
                platform != null &&
                platform.Region.RegionName.Contains(searchRequest.SearchText.ToLower()));
        
        if(searchRequest.PostedAt != default)
            searchPredicates.Add(platform => 
                platform != null &&
                platform.Advertising.PublishDate.Date == searchRequest.PostedAt.Date
            );
        
        return searchPredicates;
    }
}