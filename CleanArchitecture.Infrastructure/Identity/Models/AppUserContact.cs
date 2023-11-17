using CleanArchitecture.Infrastructure.Identity.Models;

namespace CleanArchitecture.Domain.Entities;

public class AppUserContact:BaseEntity
{
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string CountryCode { get; set; }
    public string EmailAddress { get; set; }
    public AppUser User { get; set; }
}
