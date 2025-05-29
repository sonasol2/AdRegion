using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class AdvertisingModel : DomainModel, IAdvertisingModel
{
    private readonly AdvertisingEntity _advertisingEntity;

    public AdvertisingModel(AdvertisingEntity advertisingEntity)
    {
        _advertisingEntity = advertisingEntity;
    }

    public Guid AdvertisingId => _advertisingEntity.Id;
    
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