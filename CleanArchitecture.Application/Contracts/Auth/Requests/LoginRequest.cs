namespace CleanArchitecture.Application.Contracts.Auth.Requests;

public class LoginRequest
{
    public string username { get; set; }
    public string password { get; set; }
    public bool rememberMe { get; set; }
}
