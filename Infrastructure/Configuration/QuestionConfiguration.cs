using Domain.Lesson;
using Domain.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .HasConversion(lessonId => lessonId.Value,
            value => new QuestionId(value));

        builder.HasOne<Lesson>()
            .WithMany()
            .HasForeignKey(q => q.LessonId)
            .IsRequired();

        builder.Property(q => q.Prompt).HasColumnType("nvarchar(max)");
        builder.Property(q => q.Answer).HasColumnType("nvarchar(max)");
        builder.Property(q => q.PossibleAnswers).HasColumnType("nvarchar(max)");
    }
}
