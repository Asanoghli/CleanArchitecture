using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;
public interface BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public AppUser CreatedByUser { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
    public AppUser? UpdatedByUser { get; set; }

    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public AppUser? DeletedByUser { get; set; }
}
