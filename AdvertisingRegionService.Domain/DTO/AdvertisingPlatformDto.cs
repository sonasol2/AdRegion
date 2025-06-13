namespace AdvertisingRegionService.Domain.DTO;

public class AdvertisingPlatformDto
{
    public Guid Id { get; set; }
    public AdvertisingDto? Advertising { get; set; }
    public RegionDto? Region { get; set; }
}