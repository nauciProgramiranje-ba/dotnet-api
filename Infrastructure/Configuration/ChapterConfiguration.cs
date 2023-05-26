using Domain.Chapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion(chapterId => chapterId.Value,
            value => new ChapterId(value));

        builder.Property(c => c.Title).HasMaxLength(124);
        builder.Property(c => c.Title).HasMaxLength(512);
    }
}
