namespace CleanArchitecture.Application.Contracts.Admin.Page.Requests;
public class AdminCreatePageRequestModel
{
    public string title { get; set; }
    public string titleEng { get; set; }
    public string description { get; set; }
    public string descriptionEng { get; set; }
    public string slug { get; set; }
    public string slugEng { get; set; }
}
