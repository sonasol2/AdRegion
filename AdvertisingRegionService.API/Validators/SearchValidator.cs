using AdvertisingRegionService.API.Models.Requests;
using AdvertisingRegionService.Domain.Constants;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class SearchValidator : AbstractValidator<SearchRequest>
{
    public SearchValidator()
    {
        RuleFor(s => s)
            .NotNull().WithMessage(LocalizationConstants.NullModelMessage);
        
        RuleFor(s => s.SearchText)
            .NotNull().WithMessage(LocalizationConstants.NullModelMessage)
            .NotEmpty().WithMessage(LocalizationConstants.EmptySearchStringMessage)
            .Length(ValidationConstants.MinSearchLength, ValidationConstants.MaxSearchLength)
            .WithMessage($"Lenght must be at {ValidationConstants.MinSearchLength} to {ValidationConstants.MaxSearchLength} symbols");
    }
}