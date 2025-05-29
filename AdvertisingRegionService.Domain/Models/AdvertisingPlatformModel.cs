using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.Domain.Models;

public class AdvertisingPlatformModel : DomainModel
{
    private readonly AdvertisingPlatformEntity _advertisingPlatform;
    private readonly IAdvertisingPlatformRepository _advertisingPlatformRepository;

    public AdvertisingPlatformModel(AdvertisingPlatformEntity advertisingPlatform, IAdvertisingPlatformRepository advertisingPlatformRepository)
    {
        _advertisingPlatform = advertisingPlatform;
        _advertisingPlatformRepository = advertisingPlatformRepository;
    }

    public Guid AdvertisingPlatformId => _advertisingPlatform.Id;

    public AdvertisingModel AdvertisingModel {get; }

    public RegionModel RegionModel {get;}
    
}