namespace CleanArchitecture.Domain.Entities;
public class SlideItem:BaseEntity
{
    public string? Title{ get; set; }
    public string? TitleEng { get; set; }
    public string? Description { get; set; }
    public string? DescriptionEng { get; set; }
    public string? ImagePath { get; set; }
    public string? ImagePathEng { get; set; }
    public byte OrderNumber { get; set; }
    public bool IsActive { get; set; }

}
