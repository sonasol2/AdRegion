using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class Advertising : IAdvertising
{
    private readonly AdvertisingEntity _advertisingEntity;

    public Advertising(AdvertisingEntity advertisingEntity)
    {
        _advertisingEntity = advertisingEntity;
    }

    public Guid Id => _advertisingEntity.Id;
    
    public HashSet<string> AdvertisingName
    {
        get => _advertisingEntity.PlatformsName;
        set =>  _advertisingEntity.PlatformsName = value;}

    public DateTime PublishDate
    {
        get => _advertisingEntity.PostedAt;
        set => _advertisingEntity.PostedAt = value;
    }
}