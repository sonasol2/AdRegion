using AdvertisingRegionService.Domain.Constants;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class SearchValidator : AbstractValidator<string>
{
    public SearchValidator()
    {
        RuleFor(s => s)
            .NotEmpty()
            .WithMessage(LocalizationConstants.EmptySearchStringMessage);
        
        RuleFor(s => s.Length)
            .GreaterThan(0)
            .WithMessage(LocalizationConstants.TooLongSearchStringMessage)
            .LessThan(ValidationConstants.MaxSearchLength)
            .WithMessage(LocalizationConstants.TooShortSearchStringMessage);
    }
}