namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IPlatformModel
{
    public Guid Id { get; }
    public string PlatformName { get; }
}