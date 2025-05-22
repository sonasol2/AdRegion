using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Services;

public class AdvertisingRegionService : IAdvertisingRegionService
{
    private readonly IAdvertisingRegionFileParser _advertisingRegionFileParser;
    private  readonly ICacheRepository _cacheRepository;
    
    public AdvertisingRegionService(IAdvertisingRegionFileParser advertisingRegionFileParser, ICacheRepository cacheRepository)
    {
        _advertisingRegionFileParser = advertisingRegionFileParser;
        _cacheRepository = cacheRepository;
    }

    public async Task<ExecutionResult<bool>> UploadFile(Stream file)
    {
        using var reader = new StreamReader(file);
        var content = await reader.ReadToEndAsync();

        var advertisingPlatforms = _advertisingRegionFileParser.Parse(content);
        
        UpdateCache(advertisingPlatforms);

        return ExecutionResult<bool>.Success(true);
    }

    public ExecutionResult<HashSet<string>> GetPlatformByLocation(string searchRequest) 
    {
        return ExecutionResult<HashSet<string>>.Success(_cacheRepository.GetAdvertisingPlatformByLocation(searchRequest));
    }

    private void UpdateCache(List<AdvertisingPlatform> advertisingPlatforms)
    {
        _cacheRepository.ClearCache();
        _cacheRepository.AddRange(advertisingPlatforms);
    }
}