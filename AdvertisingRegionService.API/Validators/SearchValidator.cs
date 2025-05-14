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
            .GreaterThan(0)
            .WithMessage(Constants.TooLongSearchStringMessage)
            .LessThan(Constants.MaxSearchLength)
            .WithMessage(Constants.TooShortSearchStringMessage);
    }
}