using Microsoft.EntityFrameworkCore;
using PassingTrips.Configurations;
using PassingTrips.Models;

namespace PassingTrips;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Coordinate> Coordinates { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Trip> Trips { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TripEntityConfiguration());
    }
}