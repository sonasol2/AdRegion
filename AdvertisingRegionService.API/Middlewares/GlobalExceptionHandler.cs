using System.Net;
using System.Text.Json;
using AdvertisingRegionService.API.Models.Responses;
using AdvertisingRegionService.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace AdvertisingRegionService.API.Middlewares;

/// <summary>
/// Middleware for global exception handling
/// </summary>
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly  ILogger<GlobalExceptionHandler> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception,"Error: {Message}", exception.Message);

        var response = new ErrorResponse()
        {
            StackTrace = _webHostEnvironment.IsDevelopment() ? exception.StackTrace : string.Empty,
        };

        switch (exception)
        {
            case ArgumentNullException:
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = exception.Message;
                break;
            case TimeoutException:
                response.StatusCode = HttpStatusCode.RequestTimeout;
                response.Message = exception.Message;
                break;
            case AdvertisingFileProcessingException:
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = exception.Message;
                break;
            case SearchException:
                response.StatusCode = HttpStatusCode.InternalServerError;
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