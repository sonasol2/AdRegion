using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Abstractions;

public interface IAdvertisingRegionService
{
    Task<bool> UploadFile(Stream stream);
    HashSet<string> GetPlatformByLocation(string location);
}