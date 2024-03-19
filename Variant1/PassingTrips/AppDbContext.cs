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

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            FirstName = "Вася",
            LastName = "Пупкин",
            Login = "login123",
            Password = "qwerty1!Q",
            DateRegistration = default,
            NumberPhone = "1234567890",
            DrivingExperience = 1,
        });

        modelBuilder.Entity<City>().HasData(new List<City>
        {
            new()
            {
                Id = 1,
                Name = "Москва",
                CoordinateId = 1
            },
            new()
            {
                Id = 2,
                Name = "Казань",
                CoordinateId = 2
            }
        });

        modelBuilder.Entity<Coordinate>().HasData(new List<Coordinate>
        {
            new() { Id = 1, Width = 0, Longitude = 0 },
            new() { Id = 2, Width = 50, Longitude = 0 }
        });
    }
}