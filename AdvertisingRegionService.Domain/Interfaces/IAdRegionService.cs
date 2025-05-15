using AdvertisingRegionService.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AdvertisingRegionService.Domain.Interfaces;

public interface IAdRegionService
{
    Task<WorkResult<bool>> UploadFile(IFormFile? file);
    WorkResult<HashSet<string>> GetPlatformByLocation(string location);
}