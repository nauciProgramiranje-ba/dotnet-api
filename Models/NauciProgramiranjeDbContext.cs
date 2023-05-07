using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Models;

public partial class NauciProgramiranjeDbContext : DbContext
{
    public NauciProgramiranjeDbContext()
    {
    }

    public NauciProgramiranjeDbContext(DbContextOptions<NauciProgramiranjeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<UserProgress> UserProgresses { get; set; }

    public virtual DbSet<UserTransaction> UserTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chapter__3214EC07C3DF2C9B");

            entity.ToTable("Chapter");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lesson__3214EC076522C6E0");

            entity.ToTable("Lesson");

            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Video).HasMaxLength(255);

            entity.HasOne(d => d.Chapter).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lesson__ChapterI__5EBF139D");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC070D558CE1");

            entity.ToTable("Question");

            entity.Property(e => e.Answer).HasMaxLength(255);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.Prompt).HasMaxLength(255);

            entity.HasOne(d => d.Lesson).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__Lesson__619B8048");
        });

        modelBuilder.Entity<UserProgress>(entity =>
        {
            entity.HasKey(e => new { e.QuestionId, e.UserId }).HasName("PK__UserProg__DCB8E346F122C3D8");

            entity.ToTable("UserProgress");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Question).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProgr__Quest__66603565");
        });

        modelBuilder.Entity<UserTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTran__3214EC075E7CC233");

            entity.ToTable("UserTransaction");

            entity.Property(e => e.PaidAmount).HasColumnType("money");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
