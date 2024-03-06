namespace CleanArchitecture.Domain.Entities;
public class Page : BaseEntity
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public Page? Parent { get; set; }
    public ICollection<Page> Children { get; set; } = default!;
    public string? Title { get; set; }
    public string? TitleEng { get; set; }
    public string? Description { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Slug { get; set; }
    public string? SlugEng { get; set; }
    public byte OrderNumber { get; set; }
    public string? ImagePath { get; set; }
    public string? ImagePathEng { get; set; }

    #region BaseEntity
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public AppUser CreatedByUser { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
    public AppUser? UpdatedByUser { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy {    get; set; }
    public AppUser? DeletedByUser { get; set; }
    #endregion
}
