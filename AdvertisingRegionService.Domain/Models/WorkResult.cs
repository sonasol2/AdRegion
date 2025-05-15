namespace AdvertisingRegionService.Domain.Models;

public class WorkResult<T>
{
    public bool IsSuccessfully { get; set; }
    public string? Error { get; set; }
    public T? Result { get; set; }

    public static WorkResult<T> Success(T result) => new() { IsSuccessfully = true, Result = result };
    public static WorkResult<T> Fail(string error) => new() { IsSuccessfully = false, Error = error };
}