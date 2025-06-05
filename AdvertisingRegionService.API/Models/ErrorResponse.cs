using System.Net;

namespace AdvertisingRegionService.API.Models;

public class ErrorResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}