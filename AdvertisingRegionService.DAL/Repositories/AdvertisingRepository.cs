using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class AdvertisingRepository : Repository<AdvertisingEntity>, IAdvertisingRepository
{
    public AdvertisingRepository(CacheContext<AdvertisingEntity> context) : base(context)
    {
    }
    
}