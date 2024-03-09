namespace CleanArchitecture.Application.Contracts.Admin.Users.Requests;
public class AdminUpdateUserRequest
{
    public Guid? id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public string? username { get; set; }
    public DateOnly? birthDate { get; set; }
    public string? phoneNumber { get; set; }
}
