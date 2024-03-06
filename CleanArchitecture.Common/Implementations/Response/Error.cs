using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Common.Implementations.Response;

public class Error : IError
{
    public string errorMessage { get; set; }
    public string errorKey { get; set; }
}
