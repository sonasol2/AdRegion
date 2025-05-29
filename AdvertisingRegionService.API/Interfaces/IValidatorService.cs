using FluentValidation.Results;

namespace AdvertisingRegionService.API.Interfaces;

public interface IValidatorService
{
    Task<ValidationResult> ValidateAsync<T>(T model);
}