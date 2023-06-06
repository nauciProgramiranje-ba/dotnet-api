using Domain.Chapter;
using Domain.Lesson;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasConversion(lessonId => lessonId.Value,
            value => new LessonId(value));

        builder.HasOne<Chapter>()
            .WithMany()
            .HasForeignKey(l => l.ChapterId)
            .IsRequired();

        builder.Property(l => l.Description).HasColumnType("nvarchar(max)");
    }
}
