using AdvertisingRegionService.Domain;
using FluentValidation;

namespace AdvertisingRegionService.API.Validators;

public class FormFileValidator : AbstractValidator<IFormFile>
{
    public FormFileValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage(Constants.InvalidFileNameMessage);
        
        RuleFor(x => Path.GetExtension(x.FileName).ToLower())
            .Must(ext => Constants.AllowedExtensions.Contains(ext))
            .WithMessage(Constants.InvalidFileExtensionMessage);
        
        RuleFor(x => x.Length)
            .GreaterThan(0)
            .WithMessage(Constants.EmptyObjectMessage);
    }
}