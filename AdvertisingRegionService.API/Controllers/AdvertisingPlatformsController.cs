using AdvertisingRegionService.API.Interfaces;
using AdvertisingRegionService.API.Models;
using AdvertisingRegionService.API.Requests;
using AdvertisingRegionService.API.Responses;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Constants;
using AdvertisingRegionService.Domain.DTO;
using AdvertisingRegionService.Domain.Models;
using AdvertisingRegionService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingRegionService.API.Controllers;

[ApiController]
public class AdvertisingPlatformsController : Controller
{
    private readonly IAdvertisingRegionService _advertisingRegionService;

    public AdvertisingPlatformsController(IAdvertisingRegionService advertisingRegionService)
    {
        _advertisingRegionService = advertisingRegionService;
    }
    
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile(FileUpload request)
    {
        await using var stream = request.File.OpenReadStream();
        
        var result = await _advertisingRegionService.UploadFile(stream); 
        
        if (!result)
            return BadRequest();
        
        return Ok();
    }

    [HttpGet]
    [Route("search")]
    public IActionResult SearchPlatform([FromQuery]SearchRequest searchRequest)
    {
        
        var result = _advertisingRegionService.GetPlatformByLocation(searchRequest);
        
        if (result.Count == 0)
            return NotFound(LocalizationConstants.NotFoundMessage);
        
        return Ok(result);
    }
}