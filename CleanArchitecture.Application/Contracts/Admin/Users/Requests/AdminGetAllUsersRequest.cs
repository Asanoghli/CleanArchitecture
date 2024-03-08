using CleanArchitecture.Application.Contracts.Shared;

namespace CleanArchitecture.Application.Contracts.Admin.Users.Requests;
public class AdminGetAllUsersRequest : Pager
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public DateOnly? birthDate { get; set; }
    public string? email { get; set; }
    public string? userName { get; set; }
    public string? phoneNumber { get; set; }
}
