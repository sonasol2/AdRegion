using AdvertisingRegionService.API.Models;

namespace AdvertisingRegionService.API.Services.Interfaces;

public interface IAdRegionService
{
    Task<WorkResult<bool>> UploadFile(IFormFile? file);
    WorkResult<List<string>> GetPlatformByLocation(string location);
}