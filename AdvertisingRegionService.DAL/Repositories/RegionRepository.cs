using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL.Repositories;

public class RegionRepository : Repository<RegionEntity>, IRegionRepository
{
    private readonly CacheContext<RegionEntity> _context;

    public RegionRepository(CacheContext<RegionEntity> context) : base(context)
    {
        _context = context;
    }
    
    public override void AddRange(IEnumerable<RegionEntity> entities)
    {
        throw new NotImplementedException();
    }
}