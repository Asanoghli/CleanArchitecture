using CleanArchitecture.Common.Constants;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Context;

public partial class CleanArchitectureDbContext : IdentityDbContext<AppUser,AppRole,Guid>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CleanArchitecture;Trusted_Connection=True;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        builder.Entity<AppUser>().ToTable(DatabaseTableNames.USERS);
        builder.Entity<IdentityUserRole<Guid>>().ToTable(DatabaseTableNames.USER_ROLES);
        builder.Entity<IdentityUserLogin<Guid>>().ToTable(DatabaseTableNames.USER_LOGINS);
        builder.Entity<IdentityUserClaim<Guid>>().ToTable(DatabaseTableNames.USER_CLAIMS);
        builder.Entity<AppRole>().ToTable(DatabaseTableNames.ROLES);
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable(DatabaseTableNames.ROLE_CLAIMS);
        builder.Entity<IdentityUserToken<Guid>>().ToTable(DatabaseTableNames.USER_TOKENS);
    }

}
