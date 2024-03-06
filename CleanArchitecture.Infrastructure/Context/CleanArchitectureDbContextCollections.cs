using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;

public partial class CleanArchitectureDbContext:IdentityDbContext<AppUser,AppRole,Guid>
{
    public DbSet<AppUserContact>? Contacts { get; set; }
    public DbSet<Page>? Pages{ get; set; }
    public DbSet<SlideItem>? Slides { get; set; }
}
