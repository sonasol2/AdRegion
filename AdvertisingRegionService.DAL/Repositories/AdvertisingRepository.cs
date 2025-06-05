using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class AdvertisingRepository : Repository<AdvertisingEntity>, IAdvertisingRepository
{
    public AdvertisingRepository(CacheContext<AdvertisingEntity> context) : base(context)
    {
    }

    public override AdvertisingEntity? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public override void AddRange(IEnumerable<AdvertisingEntity> entities)
    {
        throw new NotImplementedException();
    }
}