using System.Net;
using Microsoft.AspNetCore.Mvc;
using AdvertisingRegionService.API.Extensions;
using Newtonsoft.Json;

namespace AdvertisingRegionService.API.Middlewares
{
    /// <summary>
    ///     Middleware handle for exceptions
    /// </summary>
    public class AppMiddlewareException
    {
        private readonly IWebHostEnvironment _environment;
        private readonly RequestDelegate _next;
        private readonly ILogger<AppMiddlewareException> _logger;

        public AppMiddlewareException(RequestDelegate next, IWebHostEnvironment environment, ILogger<AppMiddlewareException> logger)
        {
            _next = next;
            _environment = environment;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized);
            }
            catch (BadHttpRequestException ex) 
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (AggregateException exp)
            {
                await HandleExceptionAsync(context, exp.GetBaseException(), HttpStatusCode.InternalServerError);
            }
            catch (JsonSerializationException exp)
            {
                await HandleExceptionAsync(context, exp, HttpStatusCode.BadRequest);
            }
            catch (Exception exp)
            {
                await HandleExceptionAsync(context, exp, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        ///     Create error response
        /// </summary>
        private async Task HandleExceptionAsync(HttpContext context, Exception exp, HttpStatusCode code)
        {
            var resultObject = new ProblemDetails
            {
                Status = (int)code,
                Title = exp.Message,
                Instance = context.Request.Path,
                Type = code.ToString()
            };

            if (!_environment.IsProduction())
                resultObject.Detail = exp.FullMessage();
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            string jsonString = JsonConvert.SerializeObject(resultObject); // Сериализация в JSON
            _logger.LogError(exp, exp.Message);
            await context.Response.WriteAsync(jsonString);
        }
    }
}
