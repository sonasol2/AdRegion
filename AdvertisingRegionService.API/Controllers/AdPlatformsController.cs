using AdvertisingRegionService.API.Interfaces;
using AdvertisingRegionService.Domain;
using AdvertisingRegionService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingRegionService.API.Controllers;

[ApiController]
public class AdPlatformsController : Controller
{
    private readonly IAdRegionService _adRegionService;
    private readonly IValidatorService _validatorService;

    public AdPlatformsController(IAdRegionService adRegionService, IValidatorService validatorService)
    {
        _adRegionService = adRegionService;
        _validatorService = validatorService;
    }
    
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile(IFormFile? request)
    {   
        var validatorResult = await _validatorService.ValidateAsync(request);
        if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);
        
        
        var result = await _adRegionService.UploadFile(request); 
        if (!result.IsSuccessfully)
            return BadRequest(result.Error);
        
        return Ok(Constants.SuccessMessage);
    }

    
    [HttpGet]
    [Route("search")]
    public IActionResult GetPlatformByLocation(string? searchRequest)
    {
        var validateResult = _validatorService.ValidateAsync(searchRequest);
        if(!validateResult.Result.IsValid) return BadRequest(validateResult.Result.Errors);
        
        var result = _adRegionService.GetPlatformByLocation(searchRequest);
        
        if (!result.IsSuccessfully) return BadRequest(result.Error);

        if (result.Result.Count == 0)
            return BadRequest(Constants.NotFoundMessage);
        
        return Ok(result.Result);
    }
}