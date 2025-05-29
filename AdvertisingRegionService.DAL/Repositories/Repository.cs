using AdvertisingRegionService.DAL.Abstractions;

namespace AdvertisingRegionService.DAL.Repositories;

public abstract class Repository<T> : IRepository<T> where T: IEntity // здесь будет базовая реализация когда добавлю EF
{
    public abstract T? GetById(Guid id);
    public abstract IQueryable<T> GetAll();
    public abstract void Add(T entity);
    public abstract void AddRange(IEnumerable<T> entities);
    public abstract void Update(T entity);
    public abstract void Remove(T entity);
}