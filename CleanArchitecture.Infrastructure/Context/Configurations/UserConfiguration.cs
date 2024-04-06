using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(user => user.Contacts).WithOne(contact => contact.User);
            builder.HasMany(appuser => appuser.CreatedUsers).WithOne(createdUser => createdUser.CreatedByUser);
            builder.HasMany(appuser => appuser.UpdatedUsers).WithOne(createdUser => createdUser.UpdatedByUser);
            builder.HasMany(appuser => appuser.DeletedUsers).WithOne(createdUser => createdUser.DeletedByUser);

            builder.Property(user => user.BirthDate).IsRequired(false);
        }
    }
}
