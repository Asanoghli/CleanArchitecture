using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Identity.Configurations;
public class PagesConfiguration : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.Property(page=>page.Id).ValueGeneratedOnAdd(); // TODO : need to test without this.
        builder.Property(page => page.Title).HasMaxLength(500);
        builder.Property(page => page.TitleEng).HasMaxLength(500);
        builder.Property(page => page.Description).HasMaxLength(2000);
        builder.Property(page => page.DescriptionEng).HasMaxLength(2000);
        builder.Property(page=>page.Slug).HasMaxLength(500);
        builder.Property(page=>page.SlugEng).HasMaxLength(500);
        builder.Property(page => page.ImagePath).HasMaxLength(500);
        builder.Property(page => page.ImagePathEng).HasMaxLength(500);


        builder.HasMany(parent => parent.Children).WithOne(child => child.Parent)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
