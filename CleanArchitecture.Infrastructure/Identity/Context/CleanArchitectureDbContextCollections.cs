using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Identity;

public partial class CleanArchitectureDbContext:IdentityDbContext<AppUser,AppRole,Guid>
{
    public ICollection<AppUserContact> Contacts { get; set; }
}
