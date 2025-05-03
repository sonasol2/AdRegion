using AdvertisingRegionService.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingRegionService.API.Controllers;

[ApiController]
public class AdPlatformsController : Controller
{
    private readonly IAdRegionService _adRegionService;

    public AdPlatformsController(IAdRegionService adRegionService)
    {
        _adRegionService = adRegionService;
    }
    
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile(IFormFile? file)
    {
        if (file == null || file.Length == 0) return NotFound("File is undefined or empty");
        
        string[] fileExtensions = new []{".txt" }; 
        var name = file.FileName;

        var lastIndexDot = name.LastIndexOf('.');
        var extension = name.Substring(lastIndexDot);

        foreach (var ext in fileExtensions) 
            if (extension != ext) return BadRequest("File extension incorrect");
        
        
        using var reader = new StreamReader(file.OpenReadStream());
        var content = await reader.ReadToEndAsync();
        
        var result = _adRegionService.UploadFile(content); 
        if (!result.IsSuccessfully)
            return BadRequest(result.Error);
            
        
        return Ok("File uploaded and updated successfully");
    }

    
    [HttpGet]
    [Route("search")]
    public IActionResult GetPlatformByLocation(string? searchRequest)
    {
        if (searchRequest == null || searchRequest.Length is 0 ) return NotFound("Search request is null or empty");

        if (searchRequest.Length > 100) return BadRequest("Too large request");
            
        var result = _adRegionService.GetPlatformByLocation(searchRequest);
        
        if (!result.IsSuccessfully) return BadRequest(result.Error);

        if (result.Result.Count == 0)
            return BadRequest("No content found");
        
        
        return Ok(result.Result);
    }
}