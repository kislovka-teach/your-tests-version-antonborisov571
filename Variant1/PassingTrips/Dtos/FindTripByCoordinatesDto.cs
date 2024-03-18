using PassingTrips.Models;

namespace PassingTrips.Dtos;

public class FindTripByCoordinatesDto
{
    public Coordinate DepartureCity { get; set; }
    public Coordinate ArrivalCity { get; set; }
    public DateTime Date { get; set; }
}