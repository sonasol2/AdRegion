namespace AdvertisingRegionService.Domain.Constants;

public class ValidationConstants
{
    public static readonly string[] AllowedExtensions = new[] { ".txt", ".docx", ".doc" };
    
    public const int MaxSearchLength = 100;
    public const int MinSearchLength = 2;

    public static readonly string MaxMinSearchStringLengthMessage = $"Lenght must be at {MinSearchLength} to {MaxSearchLength} symbols.";
}