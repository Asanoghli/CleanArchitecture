using CleanArchitecture.Common.Constants;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Configurations;

public class AppUserContactConfiguration : IEntityTypeConfiguration<AppUserContact>
{
    public void Configure(EntityTypeBuilder<AppUserContact> builder)
    {
        builder.Property(userContact => userContact.EmailAddress).HasMaxLength(120);
        builder.Property(userContact => userContact.PhoneNumber).HasMaxLength(20);
        builder.Property(userContact => userContact.CountryCode).HasMaxLength(6);

        builder.Property(userContact => userContact.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        builder.ToTable(DatabaseTableNames.USER_CONTACTS);
    }
}
