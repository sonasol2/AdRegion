using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Exceptions;
using AdvertisingRegionService.Domain.Factories;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Services;
public delegate bool SearchPredicate(IAdvertisingPlatform? platform);
public class AdvertisingRegionService : IAdvertisingRegionService
{
    private readonly IAdvertisingPlatformFactory _advertisingPlatformFactory;
    private readonly IAdvertisingRegionFileParser _advertisingRegionFileParser;
    private  readonly IAdvertisingPlatformRepository _advertisingPlatformRepository;
    
    public AdvertisingRegionService(IAdvertisingRegionFileParser advertisingRegionFileParser, IAdvertisingPlatformRepository advertisingPlatformRepository, IAdvertisingPlatformFactory advertisingPlatformFactory)
    {
        _advertisingRegionFileParser = advertisingRegionFileParser;
        _advertisingPlatformRepository = advertisingPlatformRepository;
        _advertisingPlatformFactory = advertisingPlatformFactory;
    }

    public async Task<bool> UploadFile(Stream file)
    {
        using var reader = new StreamReader(file);
        var content = await reader.ReadToEndAsync();

        var advertisingPlatforms = _advertisingRegionFileParser.Parse(content);
        
        if (!advertisingPlatforms.Any())
            throw new BusinessException();
        
        UpdateCache(advertisingPlatforms);
        
        return true;
    }

    public HashSet<string> GetPlatformByRegion(string searchRequest)
    {
        return _advertisingPlatformRepository.GetByRegion(searchRequest);
    }

    public IReadOnlyCollection<IAdvertisingPlatform>? SearchPlatform(List<SearchPredicate>? searchPredicates)
    {
        var entityAdvertisingPlatforms = _advertisingPlatformRepository.GetAll();
        
        var allPlatforms  = _advertisingPlatformFactory.CreateAny(entityAdvertisingPlatforms); // а нельзя ли сюда сразу передать _advertisingPlatformRepository.GetAll(); сразу?
        
        if (searchPredicates == null)
            return allPlatforms;

        var filteredPlatforms = allPlatforms
            .Where(platform => searchPredicates.All(predicate => predicate(platform)))
            .ToList();

        return filteredPlatforms.Count == 0 
            ? new List<AdvertisingPlatform>()
            : filteredPlatforms;
    }

    private void UpdateCache(IReadOnlyCollection<AdvertisingPlatformEntity> advertisingPlatforms)
    {
        _advertisingPlatformRepository.ClearCache();
        _advertisingPlatformRepository.AddRange(advertisingPlatforms);
    }
}