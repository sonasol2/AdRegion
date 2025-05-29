using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.Domain.Abstractions;

public interface IAdvertisingRegionFileParser
{
    List<AdvertisingPlatformEntity> Parse(string fileContents);

}