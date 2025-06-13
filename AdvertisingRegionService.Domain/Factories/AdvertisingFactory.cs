using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.DAL.Repositories;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Factories;

public class AdvertisingFactory : BaseDomainFactory<IAdvertising, AdvertisingEntity>, IAdvertisingFactory
{
    public AdvertisingFactory(IAdvertisingRepository repository) : base(repository)
    {
    }


    public override IAdvertising Create(AdvertisingEntity entity)
    {
        return new Advertising(entity);
    }

    public override IEnumerable<IAdvertising> CreateAll(IEnumerable<AdvertisingEntity> entities)
    {
        var advertisings = new List<Advertising>();

        foreach (var entity in entities)
        {
            var advertising = new Advertising(entity);
            advertisings.Add(advertising);
        }
        return advertisings;
    }
}