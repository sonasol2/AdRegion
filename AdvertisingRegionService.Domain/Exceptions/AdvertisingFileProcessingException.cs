namespace AdvertisingRegionService.Domain.Exceptions;

public class AdvertisingFileProcessingException : Exception
{
    public AdvertisingFileProcessingException() : base("Uploaded file was not processed.") {}
    public AdvertisingFileProcessingException( string message ) : base( message ) { }
    public AdvertisingFileProcessingException( string message, Exception innerException ) : base( message, innerException ) { }
}