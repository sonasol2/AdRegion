namespace AdvertisingRegionService.Domain.Exceptions;

public class SearchException : Exception
{
    public SearchException() : base("Search exception") { }
    public SearchException(string message) : base(message) { }
    public SearchException(string message, Exception innerException) : base(message, innerException) { }
}