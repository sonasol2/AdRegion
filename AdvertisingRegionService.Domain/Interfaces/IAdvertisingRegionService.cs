using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Interfaces;

public interface IAdvertisingRegionService
{
    Task<ExecutionResult<bool>> UploadFile(Stream stream);
    ExecutionResult<HashSet<string>> GetPlatformByLocation(string location);
}