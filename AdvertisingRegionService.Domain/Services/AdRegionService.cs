using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.Domain.Interfaces;
using AdvertisingRegionService.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AdvertisingRegionService.Domain.Services;

public class AdRegionService : IAdRegionService
{
    private readonly IAdRegionFileParser _parser;
    private static Dictionary<string, List<string>> _cachedResults = new();
    private  readonly ICacheRepository _repository;
    public AdRegionService(IAdRegionFileParser parser, ICacheRepository repository)
    {
        _parser = parser;
        _repository = repository;
    }

    public async Task<WorkResult<bool>> UploadFile(IFormFile? file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var content = await reader.ReadToEndAsync();

        var platforms = _parser.Parse(content);
        
        var dictionary = _parser.BuildRegionHierarchy(platforms);
        
        _repository.ClearCache();
        _repository.AddRange(dictionary);

        return WorkResult<bool>.Success(true);
    }

    public WorkResult<HashSet<string>> GetPlatformByLocation(string searchRequest) 
    {
        try
        {
            return WorkResult<HashSet<string>>.Success(_repository.GetAdvertisingPlatformByLocation(searchRequest));
        }
        catch (Exception e)
        {
            WorkResult<HashSet<string>>.Fail(e.Message);
            throw;
        }
    }
}