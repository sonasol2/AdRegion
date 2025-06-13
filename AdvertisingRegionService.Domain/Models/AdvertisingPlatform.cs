using AdvertisingRegionService.DAL.Abstractions;
using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class AdvertisingPlatform : IAdvertisingPlatform
{
    private readonly AdvertisingPlatformEntity _advertisingPlatform;
    private IAdvertising _advertising;
    private IRegion _region;

    public AdvertisingPlatform(AdvertisingPlatformEntity advertisingPlatform, IAdvertising advertising, IRegion region)
    {
        _advertisingPlatform = advertisingPlatform;
        _advertising = advertising;
        _region = region;
    }

    public Guid Id => _advertisingPlatform.Id; // TODO: Подумать над организацие ID и нужен ли абстрактный класс для этого.
    public IAdvertising Advertising => _advertising;
    public IRegion Region => _region;
    
    
    
}