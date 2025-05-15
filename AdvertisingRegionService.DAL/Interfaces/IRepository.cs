using AdvertisingRegionService.Domain.Interfaces;

namespace AdvertisingRegionService.DAL.Interfaces;

public interface IRepository<T> where T : IEntity
{
    ICollection<T> GetAll();
    T GetById(Guid id);
    void Add(T entity);
    void AddRange(ICollection<T> entities);
    void Delete(T entity);
}