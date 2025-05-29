using AdvertisingRegionService.Domain.Constants;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class FormFileValidator : AbstractValidator<IFormFile>
{
    public FormFileValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage(LocalizationConstants.InvalidFileNameMessage);
        
        RuleFor(x => Path.GetExtension(x.FileName).ToLower())
            .Must(ext => ValidationConstants.AllowedExtensions.Contains(ext))
            .WithMessage(LocalizationConstants.InvalidFileExtensionMessage);
        
        RuleFor(x => x.Length)
            .GreaterThan(0)
            .WithMessage(LocalizationConstants.EmptyObjectMessage);
    }
}