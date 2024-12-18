﻿
namespace CleanArchitecture.Domain.Entities;
public class SlideItem : BaseEntity
{
    public string? Title{ get; set; }
    public string? TitleEng { get; set; }
    public string? Description { get; set; }
    public string? DescriptionEng { get; set; }
    public string? ImagePath { get; set; }
    public string? ImagePathEng { get; set; }
    public byte OrderNumber { get; set; }
    public bool IsActive { get; set; }

    #region BaseEntity
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public AppUser CreatedByUser { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
    public AppUser? UpdatedByUser { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public AppUser? DeletedByUser { get; set; }
    #endregion
}
