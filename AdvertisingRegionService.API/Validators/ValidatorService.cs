using AdvertisingRegionService.API.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace AdvertisingRegionService.API.Validators;

public class ValidatorService : IValidatorService
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<ValidationResult> ValidateAsync<T>(T model)
    {
        var validator = _serviceProvider.GetService<IValidator<T>>() 
                        ?? throw new InvalidOperationException($"No validator found for type {typeof(T).Name}");
    
        return await validator.ValidateAsync(model);
    }
}