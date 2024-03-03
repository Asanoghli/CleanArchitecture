namespace CleanArchitecture.Application.Contracts.Page.Requests;
public class CreatePageRequestModel
    {
    public string title { get; set; }
    public string titleEng { get; set; }
    public string description { get; set; }
    public string descriptionEng { get; set; }
    public string slug { get; set; }
    public string slugEng { get; set; }
}
