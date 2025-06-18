using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Repositories;

public abstract class Repository<T> : IRepository<T> where T: IEntity // здесь будет базовая реализация когда добавлю EF
{
    private readonly CacheContext<T> _context;
    
    protected Repository(CacheContext<T> context)
    {
        _context = context;
    }
    
    public virtual T? GetById(Guid id)
    {
        return _context.GetById(id);
    }

    public virtual IReadOnlyCollection<T> GetAll()
    {
        return _context.GetAll();
    }

    public virtual void Add(T entity)
    {
        _context.Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.AddRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Update(entity);
    }

    public virtual void Remove(T entity)
    {
        _context.Remove(entity);
    }
}