using AdvertisingRegionService.API.Models;
using AdvertisingRegionService.API.Requests;
using AdvertisingRegionService.Domain.Constants;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class FormFileValidator : AbstractValidator<FileUpload>
{
    public FormFileValidator()
    {
        RuleFor(f => f.File)
            .NotNull().WithMessage(LocalizationConstants.NullModelMessage)
            .NotEmpty().WithMessage(LocalizationConstants.EmptyObjectMessage);

        RuleFor(f => f.File.Length)
            .GreaterThan(0)
            .WithMessage(LocalizationConstants.EmptyObjectMessage);
        
        RuleFor(x => Path.GetExtension(x.File.FileName!).ToLower())
            .Must(ext => ValidationConstants.AllowedExtensions.Contains(ext))
            .WithMessage(LocalizationConstants.InvalidFileExtensionMessage);
    }
}