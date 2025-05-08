using FluentValidation.Results;

namespace AdvertisingRegionService.API.Services.Interfaces;

public interface IValidatorService
{
    Task<ValidationResult> ValidateAsync<T>(T model);
}