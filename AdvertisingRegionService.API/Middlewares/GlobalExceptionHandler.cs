using System.Net;
using System.Text.Json;
using AdvertisingRegionService.API.Models;
using AdvertisingRegionService.API.Responses;
using AdvertisingRegionService.Domain.Constants;
using Microsoft.AspNetCore.Diagnostics;

namespace AdvertisingRegionService.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly  ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception,"Error: {Message}", exception.Message);

        var response = new ErrorResponse();

        switch (exception)
        {
            case ArgumentNullException:
            case NullReferenceException:
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = exception.Message;
                break;
            case ArgumentException:
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = exception.Message;
                break;
            case KeyNotFoundException:
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = exception.Message;
                break;
            case TimeoutException:
                response.StatusCode = HttpStatusCode.RequestTimeout;
                response.Message = exception.Message;
                break;
            default:
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = exception.Message;
                break;
        }
       
        httpContext.Response.StatusCode = (int)response.StatusCode;
        httpContext.Response.ContentType = "application/json";
        
        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        await httpContext.Response.WriteAsync(jsonResponse, cancellationToken);
        
        return true;
    }
}