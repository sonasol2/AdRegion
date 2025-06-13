using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;
using AdvertisingRegionService.Domain.Services;

namespace AdvertisingRegionService.Domain.Abstractions;

public interface IAdvertisingRegionService
{
    Task<bool> UploadFile(Stream stream);
    HashSet<string> GetPlatformByRegion(string location);
    IEnumerable<IAdvertisingPlatform>? SearchPlatform(List<SearchPredicate> searchPredicates);
}