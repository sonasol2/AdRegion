using AdvertisingRegionService.DAL.Interfaces;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class CacheRepository: ICacheRepository
{
    private readonly CacheContext _context;

    public CacheRepository(CacheContext context)
    {
        _context = context;
    }

    public ICollection<AdvertisingPlatform> GetAll()
    {
        try
        {
            return _context.AdvertisingPlatform.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public AdvertisingPlatform GetById(Guid id)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(id));
        
        return _context.AdvertisingPlatform.FirstOrDefault(ap => ap.Id == id)!;
    }

    public void Add(AdvertisingPlatform entity)
    {
        try
        {
            _context.AdvertisingPlatform.Add(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddRange(ICollection<AdvertisingPlatform> entities)
    {
        try
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (_context.AdvertisingPlatform is List<AdvertisingPlatform> list)
            {
                list.AddRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    _context.AdvertisingPlatform.Add(entity);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void Delete(AdvertisingPlatform entity)
    {
        try
        {
            _context.AdvertisingPlatform.Remove(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ClearCache()
    {
        try
        {
            _context.AdvertisingPlatform.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public HashSet<string> GetAdvertisingPlatformByLocation(string location)
    {
        ArgumentException.ThrowIfNullOrEmpty(location);
        
        return _context.AdvertisingPlatform
            .FirstOrDefault(ap => ap.Region.Contains(location))!
            .Platforms;
    }
}