using AdvertisingRegionService.API.Models.Requests;
using AdvertisingRegionService.Domain.Services;

namespace AdvertisingRegionService.API.Services;

public class PredicateSearchFactory
{
    public static List<SearchPredicate> CreateSearchPredicates(SearchRequest searchRequest) // вынес сюда чтобы сделать контроллер чище
    {
        var searchPredicates = new List<SearchPredicate>();
        var searchText = searchRequest.SearchText.ToLower();
        
        if (!string.IsNullOrEmpty(searchText)) 
            searchPredicates.Add(platform =>
                platform != null &&
                platform.Region.RegionName.ToLower() == searchText);
        
        if(searchRequest.PostedAt != default)
            searchPredicates.Add(platform => 
                platform != null &&
                platform.Advertising.PublishDate.Date == searchRequest.PostedAt.Date
            );
        
        return searchPredicates;
    }
}