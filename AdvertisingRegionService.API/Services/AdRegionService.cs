using AdvertisingRegionService.API.Models;
using AdvertisingRegionService.API.Services.Interfaces;

namespace AdvertisingRegionService.API.Services;

public class AdRegionService : IAdRegionService
{
    private Dictionary<string, List<string>> _platforms = new();
    private static Dictionary<string, List<string>> _cachedResults = new();
    
    public WorkResult<bool> UploadFile(string fileContent)
    {
        string? b = null;
        foreach (var line in fileContent.Split('\n'))
        {
            var parts = line.Split(':'); 
            if (parts.Length == 2)
            {
                var platform = parts[0].Trim();
                var locations = parts[1].Split(',').Select(l => l.Trim().TrimEnd()).ToList();
                
                foreach (var location in locations) 
                {
                    if (!_platforms.ContainsKey(location))
                        _platforms[location] = new List<string>();
                    if (!_platforms[location].Contains(platform))
                        _platforms[location].Add(platform);                
                }
            } 
        }
        
        BuildCache(); 
        return WorkResult<bool>.Success(true);
    }

    public WorkResult<List<string>> GetPlatformByLocation(string searchRequest) 
    {
        if (string.IsNullOrWhiteSpace(searchRequest))
            return WorkResult<List<string>>.Fail("Location cannot be empty");
        
        return _cachedResults.ContainsKey(searchRequest) 
            ? WorkResult<List<string>>.Success(_cachedResults[searchRequest])
            : WorkResult<List<string>>.Success(new List<string>());
    }
    
    
    private void BuildCache() 
    {
        _cachedResults.Clear(); 
        
        foreach (var location in _platforms.Keys)
        {
            var currentLocation = location;
            var platformsForLocation = new List<string>();
            
            while (!string.IsNullOrEmpty(currentLocation)) 
            {
                if (_platforms.ContainsKey(currentLocation))
                    platformsForLocation.AddRange(_platforms[currentLocation]);
                
                var lastSlashIndex = currentLocation.LastIndexOf('/'); 
                currentLocation = lastSlashIndex > 0 ? currentLocation.Substring(0, lastSlashIndex) : string.Empty;
            }
            
            _cachedResults[location] = platformsForLocation.Distinct().ToList();
        }
        _platforms.Clear(); 
    }
}