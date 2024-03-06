using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Common.Implementations.Response;

public class Response<T> : IResponse<T>
{
    public bool isSuccess { get; set; } = false;
    public string message { get; set; }
    public T data { get; set; }
    public IEnumerable<IError> errors { get; set; }
}
