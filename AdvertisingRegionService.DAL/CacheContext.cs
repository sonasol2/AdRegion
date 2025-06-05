using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL;

public class CacheContext<T> //TODO: больше сымитировать БД, сделать статическим с синх. 
{
    private static ICollection<T> advertisingPlatform { get; set; }

    static CacheContext()
    {
        advertisingPlatform = new List<T>();
    }
    
    public ICollection<T> AdvertisingPlatform => advertisingPlatform;

    public void Add(T entity)
    {
        advertisingPlatform.Add(entity);
    }

    public void Remove(T entity)
    {
        advertisingPlatform.Remove(entity);
    }

    public void Update(T entity)
    {
        advertisingPlatform.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return advertisingPlatform.AsQueryable();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            advertisingPlatform.Add(entity);
        }
    }
}
    