using AdRegion.Models;

namespace AdRegion.Services.Interfaces;

public interface IAdRegionService
{
    WorkResult<bool> UploadFile(string parsedFile);
    WorkResult<List<string>> GetPlatformByLocation(string location);
}