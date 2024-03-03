namespace CleanArchitecture.Domain.Entities;
public class Page:BaseEntity
{
    public Guid? ParentId { get; set; }
    public Page? Parent { get; set; }
    public ICollection<Page> Children { get; set; }
    public string? Title { get; set; }
    public string? TitleEng { get; set; }
    public string? Description { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Slug { get; set; }
    public string? SlugEng { get; set; }
    public byte OrderNumber { get; set; }
    public string? ImagePath { get; set; }
    public string? ImagePathEng { get; set; }
}
