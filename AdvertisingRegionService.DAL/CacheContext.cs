using AdvertisingRegionService.DAL.Models;

namespace AdvertisingRegionService.DAL;

public class CacheContext //TODO: больше сымитировать БД, сделать статическим с синх. 
{
    public ICollection<AdvertisingPlatform> AdvertisingPlatform { get; set; } = new List<AdvertisingPlatform>();
}
    