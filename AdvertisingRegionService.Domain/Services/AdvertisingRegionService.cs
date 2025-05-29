using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Services;

public class AdvertisingRegionService : IAdvertisingRegionService
{
    private readonly IAdvertisingRegionFileParser _advertisingRegionFileParser;
    private  readonly IAdvertisingPlatformRepository _advertisingPlatformRepository;
    
    public AdvertisingRegionService(IAdvertisingRegionFileParser advertisingRegionFileParser, IAdvertisingPlatformRepository advertisingPlatformRepository)
    {
        _advertisingRegionFileParser = advertisingRegionFileParser;
        _advertisingPlatformRepository = advertisingPlatformRepository;
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
        return ExecutionResult<HashSet<string>>.Success(_advertisingPlatformRepository.GetAdvertisingPlatformByLocation(searchRequest));
    }

    private void UpdateCache(List<AdvertisingPlatformEntity> advertisingPlatforms)
    {
        _advertisingPlatformRepository.ClearCache();
        _advertisingPlatformRepository.AddRange(advertisingPlatforms);
    }
}