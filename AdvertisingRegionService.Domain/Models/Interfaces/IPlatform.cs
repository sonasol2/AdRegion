namespace AdvertisingRegionService.Domain.Models.Interfaces;

public interface IPlatform : IDomainModel
{
    public Guid Id { get; }
    public string PlatformName { get; }
}