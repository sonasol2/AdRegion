
using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL;

public class CacheContext<T> where T : IEntity
{
    private static readonly object _lock = new();
    private static ICollection<T> advertisingPlatform { get; set; } = new List<T>();
    
    
    public ICollection<T> AdvertisingPlatform => advertisingPlatform;
    
    public T? GetById(Guid id)
    {
        lock (_lock)
        {
            return advertisingPlatform.FirstOrDefault(entity => entity.Id == id);
        }
    }
    
    public void Add(T entity)
    {
        lock (_lock)
        {
            advertisingPlatform.Add(entity);
        }
    }

    public void Remove(T entity)
    {
        lock (_lock)
        {
            advertisingPlatform.Remove(entity);
        }
    }

    public void Update(T entity)
    {
        lock (_lock)
        {
            throw new NotImplementedException();  //TODO: дописать обновление
        }
    }

    public IReadOnlyCollection<T> GetAll()
    {
        lock (_lock)
        {
            return advertisingPlatform.Select(entity => entity).ToList();
        }
    }

    public void AddRange(IEnumerable<T> entities)
    {
        lock (_lock)
        {
            foreach (var entity in entities)
            {
                advertisingPlatform.Add(entity);
            }
        }
    }
}
    