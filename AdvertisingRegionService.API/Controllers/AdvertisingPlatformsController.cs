using AdvertisingRegionService.API.Interfaces;
using AdvertisingRegionService.Domain.Abstractions;
using AdvertisingRegionService.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingRegionService.API.Controllers;

[ApiController]
public class AdvertisingPlatformsController : Controller
{
    private readonly IAdvertisingRegionService _advertisingRegionService;
    private readonly IValidatorService _validatorService;

    public AdvertisingPlatformsController(IAdvertisingRegionService advertisingRegionService, IValidatorService validatorService)
    {
        _advertisingRegionService = advertisingRegionService;
        _validatorService = validatorService;
    }
    
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile(IFormFile? request)
    {   
        // var validatorResult = await _validatorService.ValidateAsync(request);
        // if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);
        
        await using var stream = request.OpenReadStream();
        
        var result = await _advertisingRegionService.UploadFile(stream); 
        if (!result.IsSuccessfully)
            return BadRequest(result.Error);
        
        return Ok(LocalizationConstants.SuccessMessage);
    }

    
    [HttpGet]
    [Route("search")]
    public IActionResult GetPlatformByLocation(string? searchRequest)
    {
        var validateResult = _validatorService.ValidateAsync(searchRequest);
        if(!validateResult.Result.IsValid) return BadRequest(validateResult.Result.Errors);
        
        var result = _advertisingRegionService.GetPlatformByLocation(searchRequest);
        
        if (!result.IsSuccessfully) return BadRequest(result.Error);

        if (result.Result.Count == 0)
            return BadRequest(LocalizationConstants.NotFoundMessage);
        
        return Ok(result.Result);
    }
}