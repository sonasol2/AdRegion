namespace AdvertisingRegionService.Domain;

public static class Constants
{
    public static readonly string[] AllowedExtensions = new[] { ".txt", ".docx", ".doc", ".pdf" };
    
    
    public const int MaxSearchLength = 100;
    public const int MinSearchLength = 2;
    
    //message
    public const string NotFoundMessage = "Not found";
    public const string BadRequestMessage = "Bad Request";
    public const string SuccessMessage = "Success";
    
    public const string EmptyObjectMessage = "Object is empty";
    public const string EmptyElementMessage = "Object is empty";
    public const string EmptySearchStringMessage = "Search string is empty";
    
    public const string TooLongSearchStringMessage = "Search string is too long";
    public const string TooShortSearchStringMessage = "Search string is too short";
    public const string FileIsRequiredMessage = "File is required";
    
    public const string InvalidFileExtensionMessage = "Incorrect file extension";
    public const string InvalidSearchStringMessage = "Search string is invalid";
    public const string InvalidFileNameMessage = "Invalid file name";
    public const string InvalidFileMessage = "Invalid file";
    
    public const string NullModelMessage = "Model is null";
}