namespace AdvertisingRegionService.API.Models.Requests;

public class SearchRequest
{
    public string? SearchText { get; set; }
    public DateTime PostedAt { get; set; }
}