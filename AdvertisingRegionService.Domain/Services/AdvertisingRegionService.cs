using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Factories;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Services;

public class AdvertisingRegionService : IAdvertisingRegionService
{
    private readonly IAdvertisingPlatformFactory advertisingPlatformFactory;
    private readonly IAdvertisingRegionFileParser _advertisingRegionFileParser;
    private  readonly IAdvertisingPlatformRepository _advertisingPlatformRepository;
    
    public AdvertisingRegionService(IAdvertisingRegionFileParser advertisingRegionFileParser, IAdvertisingPlatformRepository advertisingPlatformRepository, IAdvertisingPlatformFactory advertisingPlatformFactory)
    {
        _advertisingRegionFileParser = advertisingRegionFileParser;
        _advertisingPlatformRepository = advertisingPlatformRepository;
        this.advertisingPlatformFactory = advertisingPlatformFactory;
    }

    public async Task<bool> UploadFile(Stream file)
    {
        using var reader = new StreamReader(file);
        var content = await reader.ReadToEndAsync();

        var advertisingPlatforms = _advertisingRegionFileParser.Parse(content);
        
        UpdateCache(advertisingPlatforms);

        return true;
    }

    public HashSet<string> GetPlatformByLocation(string searchRequest) 
    {
        return _advertisingPlatformRepository.GetAdvertisingPlatformByLocation(searchRequest);
    }

    private void UpdateCache(List<AdvertisingPlatformEntity> advertisingPlatforms)
    {
        _advertisingPlatformRepository.ClearCache();
        _advertisingPlatformRepository.AddRange(advertisingPlatforms);
    }
}