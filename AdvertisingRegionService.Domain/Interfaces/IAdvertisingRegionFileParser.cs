using AdvertisingRegionService.DAL.Models;
using AdvertisingRegionService.Domain.Models;

namespace AdvertisingRegionService.Domain.Interfaces;

public interface IAdvertisingRegionFileParser
{
    List<AdvertisingPlatform> Parse(string fileContents);

}