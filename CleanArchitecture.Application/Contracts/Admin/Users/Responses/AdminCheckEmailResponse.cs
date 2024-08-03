namespace CleanArchitecture.Application.Contracts.Admin.Users.Responses;
public class AdminCheckEmailResponse
    {
    public Guid userId { get; set; }
    public bool isExists { get; set; }
}
