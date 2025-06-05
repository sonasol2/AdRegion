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

    public override RegionEntity? GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public override void AddRange(IEnumerable<RegionEntity> entities)
    {
        throw new NotImplementedException();
    }

    public override IQueryable<RegionEntity> GetAll()
    {
        throw new NotImplementedException();
    }
}