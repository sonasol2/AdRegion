using AdvertisingRegionService.API.Models.Requests;
using AdvertisingRegionService.API.Services;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Constants;
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
        var searchPredicates = PredicateSearchFactory.CreateSearchPredicates(searchRequest);
        var result = _advertisingRegionService.SearchPlatform(searchPredicates);
        if (result == null || !result.Any())
            return NotFound(LocalizationConstants.NotFoundMessage);
        
        var searchResponse = Mapper.MapSearchResponse(result);
        
        return Ok(searchResponse);
    }
}