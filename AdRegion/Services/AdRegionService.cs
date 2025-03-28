using AdRegion.Models;
using AdRegion.Services.Interfaces;

namespace AdRegion.Services;

public class AdRegionService : IAdRegionService
{
    private Dictionary<string, List<string>> _platforms = new();
    private Dictionary<string, List<string>> _cachedResults = new();
    
    public WorkResult<bool> UploadFile(string fileContent) // метод загрузки
    {
        foreach (var line in fileContent.Split('\n'))
        {
            var parts = line.Split(':'); // делю на строки
            if (parts.Length == 2)
            {
                var platform = parts[0].Trim(); // отделяю платформы
                var locations = parts[1].Split(',').Select(l => l.Trim().TrimEnd()).ToList(); // отделяю локации единым куском
                
                foreach (var location in locations) // собираю словарь. ключ: локация(ru/ итд), значениее платформа(Яндекс.диркет и тд)
                {
                    if (!_platforms.ContainsKey(location))
                        _platforms[location] = new List<string>();
                    if (!_platforms[location].Contains(platform))
                        _platforms[location].Add(platform);                
                }
            } 
        }
        
        BuildCache(); // собираю "кеш" для более эффективного поиска
        return WorkResult<bool>.Success(true);
    }

    public WorkResult<List<string>> GetPlatformByLocation(string searchRequest) // метод поиска
    {
        if (string.IsNullOrWhiteSpace(searchRequest))
            return WorkResult<List<string>>.Fail("Location cannot be empty");
        
        
        return _cachedResults.ContainsKey(searchRequest) // Просто возвращаем подготовленный заранее список по ключу из "кеша" по идее это максимально приближено к O(1)
            ? WorkResult<List<string>>.Success(_cachedResults[searchRequest])
            : WorkResult<List<string>>.Success(new List<string>());
    }
    
    
    private void BuildCache() // метод "кеширования"
    {
        _cachedResults.Clear(); // чищу от предыдущих результатов

        // просматриваем все локации из _platforms
        foreach (var location in _platforms.Keys)
        {
            var currentLocation = location;
            var platformsForLocation = new List<string>();
            
            while (!string.IsNullOrEmpty(currentLocation)) 
            {
                if (_platforms.ContainsKey(currentLocation))
                    platformsForLocation.AddRange(_platforms[currentLocation]);
                
                // проверяем индексы локаций с конца, отделяем дочерние и присваиваем родительские к текущей локации, в псоследтвии добавляя ее как новый ключ к текущей платформе 
                var lastSlashIndex = currentLocation.LastIndexOf('/'); // берем последний вход слэша
                currentLocation = lastSlashIndex > 0 ? currentLocation.Substring(0, lastSlashIndex) : string.Empty;
            }
            
            _cachedResults[location] = platformsForLocation.Distinct().ToList();
        }
        
        _platforms.Clear(); // очищаю память чисткой _platforms, в текущей задаче он не нужен, но в теории был бы удобен при загрузки новых данных чтобы не перезагружать все заново
    }
}