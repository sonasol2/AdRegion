using AdvertisingRegionService.Domain;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class SearchValidator : AbstractValidator<string>
{
    public SearchValidator()
    {
        RuleFor(s => s)
            .NotEmpty()
            .WithMessage(Constants.EmptySearchStringMessage);
        
        RuleFor(s => s.Length)
            .GreaterThan(Constants.MaxSearchLength)
            .WithMessage(Constants.TooLongSearchStringMessage)
            .LessThan(0)
            .WithMessage(Constants.TooShortSearchStringMessage);
    }
}