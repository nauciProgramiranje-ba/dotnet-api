using Domain.Chapter;
using Domain.Lesson;
using Domain.Question;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class NauciProgramiranjeDbContext : DbContext
{
    public NauciProgramiranjeDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NauciProgramiranjeDbContext).Assembly);
    }

    // public DbSet<User> User { get; set; }

    public DbSet<Chapter> Chapter { get; set; }

    public DbSet<Lesson> Lesson { get; set; }
    
    public DbSet<Question> Question { get; set; }
    
    // public DbSet<UserProgress> UserProgress { get; set; }
    
    // public DbSet<UserTransaction> UserTransaction { get; set; }
}
