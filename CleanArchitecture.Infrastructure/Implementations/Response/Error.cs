using CleanArchitecture.Application.Interfaces.Responses;

namespace CleanArchitecture.Infrastructure.Implementations.Response;

public class Error : IError
{
    public string errorMessage { get; set; }
    public string errorKey { get; set; }
}
