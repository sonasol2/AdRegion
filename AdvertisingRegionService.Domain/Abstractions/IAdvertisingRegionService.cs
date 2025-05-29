using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Abstractions;

public interface IAdvertisingRegionService
{
    Task<ExecutionResult<bool>> UploadFile(Stream stream);
    ExecutionResult<HashSet<string>> GetPlatformByLocation(string location);
}