using AdvertisingRegionService.API.Models;
using AdvertisingRegionService.API.Services.Interfaces;
using AdvertisingRegionService.Domain.Parsers;

namespace AdvertisingRegionService.API.Services;

public class AdRegionService : IAdRegionService
{
    private readonly AdRegionFileParser _parser;
    private static Dictionary<string, List<string>> _cachedResults = new();

    
    public AdRegionService(AdRegionFileParser parser)
    {
        _parser = new AdRegionFileParser();
    }
    
    public async Task<WorkResult<bool>> UploadFile(IFormFile? file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var content = await reader.ReadToEndAsync();
        
        var platforms = _parser.Parse(content);
        
        _cachedResults = _parser.BuildRegionHierarchy(platforms);
        return WorkResult<bool>.Success(true);
    }

    public WorkResult<List<string>> GetPlatformByLocation(string searchRequest) 
    {
        return _cachedResults.ContainsKey(searchRequest) 
            ? WorkResult<List<string>>.Success(_cachedResults[searchRequest])
            : WorkResult<List<string>>.Success(new List<string>());
    }
}