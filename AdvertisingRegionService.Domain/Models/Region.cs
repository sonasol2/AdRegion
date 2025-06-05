using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class Region : IRegion
{
    private readonly RegionEntity _regionEntity;

    public Region(RegionEntity regionEntity)
    {
        _regionEntity = regionEntity;
    }

    public Guid Id => _regionEntity.Id;
    
    public string RegionName 
    { 
        get => _regionEntity.Name;
        set => _regionEntity.Name = value;
    }
}