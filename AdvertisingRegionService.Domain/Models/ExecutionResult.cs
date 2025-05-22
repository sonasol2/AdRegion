namespace AdvertisingRegionService.Domain.Models;

public class ExecutionResult<T>
{
    public bool IsSuccessfully { get; set; }
    public string? Error { get; set; }
    public T? Result { get; set; }

    public static ExecutionResult<T> Success(T result) => new() { IsSuccessfully = true, Result = result };
    public static ExecutionResult<T> Fail(string error) => new() { IsSuccessfully = false, Error = error };
}