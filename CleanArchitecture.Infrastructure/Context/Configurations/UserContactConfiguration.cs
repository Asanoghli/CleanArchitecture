using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Configurations;
public class UserContactConfiguration : IEntityTypeConfiguration<AppUserContact>
{
    public void Configure(EntityTypeBuilder<AppUserContact> builder)
    {
        builder.Property(userContact=>userContact.UserId).IsRequired();

        builder.HasOne(appuserContact => appuserContact.User)
            .WithMany(user => user.Contacts)
            .HasForeignKey(contact=>contact.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
