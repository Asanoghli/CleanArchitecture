namespace CleanArchitecture.Application.Interfaces.Responses;

public interface IError
{
    public string errorMessage { get; set; }
    public string errorKey { get; set; }
}
