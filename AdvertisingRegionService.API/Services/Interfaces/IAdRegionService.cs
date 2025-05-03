using AdvertisingRegionService.API.Models;

namespace AdvertisingRegionService.API.Services.Interfaces;

public interface IAdRegionService
{
    WorkResult<bool> UploadFile(string parsedFile);
    WorkResult<List<string>> GetPlatformByLocation(string location);
}