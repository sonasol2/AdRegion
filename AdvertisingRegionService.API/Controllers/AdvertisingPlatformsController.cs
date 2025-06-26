using AdvertisingRegionService.API.Models.Requests;
using AdvertisingRegionService.API.Services;
using AdvertisingRegionService.Domain.Abstractions;
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
        
        await _advertisingRegionService.UploadFile(stream); 
        
        return Ok();
    }

    [HttpGet]
    [Route("search")]
    public IActionResult SearchPlatform([FromQuery]SearchRequest searchRequest)
    {
        var searchPredicates = PredicateSearchFactory.CreateSearchPredicates(searchRequest);
        var result = _advertisingRegionService.SearchPlatform(searchPredicates);
        
        var searchResponse = Mapper.MapSearchResponse(result);
        
        return Ok(searchResponse);
    }
}