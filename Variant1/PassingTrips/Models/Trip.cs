namespace PassingTrips.Models;

public class Trip
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public User Driver { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int DepartureCityId { get; set; }
    public City DepartureCity { get; set; }
    public int ArrivalCityId { get; set; }
    public City ArrivalCity { get; set; }
    public int Price { get; set; }
    public int MaxCountPassenger { get; set; }
    public List<User> Passengers { get; set; }
    public List<Review> Reviews { get; set; }
    public string Car { get; set; }
    public bool IsMusic { get; set; }
    public bool IsSmoking { get; set; }
    public bool IsAnimal { get; set; }
}