using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public interface IDomainFactory<out TDomain, in TEntity>
    where TDomain : class, IDomainModel
    where TEntity : class, IEntity
{
    TDomain Create(TEntity entity);
    IReadOnlyCollection<TDomain> CreateAny(IEnumerable<TEntity> entities);
}