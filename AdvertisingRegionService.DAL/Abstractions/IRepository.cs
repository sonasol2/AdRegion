namespace AdvertisingRegionService.DAL.Abstractions;

public interface IRepository<T> where T : IEntity
{
    IQueryable<T> GetAll();
    T? GetById(Guid id);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
}