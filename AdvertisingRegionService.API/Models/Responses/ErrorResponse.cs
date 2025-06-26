using System.Net;

namespace AdvertisingRegionService.API.Models.Responses;

public class ErrorResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? StackTrace { get; set; }
}