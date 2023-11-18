namespace CleanArchitecture.Application.Interfaces.Responses;

public interface IResponse<T>
{
    public bool isSuccess { get; set; }
    public string message { get; set; }
    public T data { get; set; }
    public IEnumerable<IError> errors { get; set; }
}
