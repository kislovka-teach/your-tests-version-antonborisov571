using Freelance.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Bid> Proposals { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "admin123", Role = UserRole.Freelancer },
            new User { Id = 2, Username = "user1", Password = "user123", Role = UserRole.Employer },
            new User { Id = 3, Username = "user2", Password = "user456", Role = UserRole.Employer }
        );
    }
}