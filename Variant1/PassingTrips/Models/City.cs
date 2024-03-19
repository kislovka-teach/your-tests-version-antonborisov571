namespace PassingTrips.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CoordinateId { get; set; }
    public Coordinate Coordinate { get; set; }
}