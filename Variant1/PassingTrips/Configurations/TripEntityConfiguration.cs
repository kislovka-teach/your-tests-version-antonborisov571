using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassingTrips.Models;

namespace PassingTrips.Configurations;

public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasOne<User>(trip => trip.Driver)
            .WithMany(user => user.DriverTrips);
        
        builder.HasMany<User>(trip => trip.Passengers)
            .WithMany(user => user.PassengerTrips);
    }
}