using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public abstract class BaseDomainFactory<TDomain, TEntity> : IDomainFactory<TDomain, TEntity>
    where TDomain : class, IDomainModel
    where TEntity : class, IEntity
{
    private readonly IRepository<TEntity> _repository;

    protected BaseDomainFactory(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public abstract TDomain Create(TEntity entity);
}