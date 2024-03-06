using CleanArchitecture.Common.Enums;

namespace CleanArchitecture.Common.Interfaces.Responses;

public interface IError
{
    public string errorMessage { get; set; }
    public string errorKey { get; set; }
}
