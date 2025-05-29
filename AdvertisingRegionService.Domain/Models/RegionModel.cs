using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models.Interfaces;

namespace AdvertisingRegionService.Domain.Models;

public class RegionModel : DomainModel, IRegionModel
{
    private readonly RegionEntity _regionEntity;

    public RegionModel(RegionEntity regionEntity)
    {
        _regionEntity = regionEntity;
    }

    public Guid RegionId => _regionEntity.Id;
    
    public string RegionName 
    { 
        get => _regionEntity.Name;
        set => _regionEntity.Name = value;
    }
}