using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public class AppUser : IdentityUser<Guid>, BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    #region Collections
    public ICollection<AppUserContact> Contacts { get; set; }
    public ICollection<AppUser> CreatedUsers { get; set; }
    public ICollection<AppUser> DeletedUsers { get; set; }
    public ICollection<AppUser> UpdatedUsers { get; set; }
    public ICollection<AppUserContact> CreatedUserContacts { get; set; }
    public ICollection<AppUserContact> DeletedUserContacts { get; set; }
    public ICollection<AppUserContact> UpdatedUserContacts { get; set; }
    #endregion


    #region BaseEntity
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CreatedById { get;set; }
    public AppUser CreatedByUser { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
    public AppUser? UpdatedByUser { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public AppUser? DeletedByUser { get; set; }
    #endregion
}
