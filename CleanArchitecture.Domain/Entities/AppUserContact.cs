namespace CleanArchitecture.Domain.Entities;

public class AppUserContact : BaseEntity
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }

    public string? PhoneNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? CountryCode { get; set; }
    public string? EmailAddress { get; set; }

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
