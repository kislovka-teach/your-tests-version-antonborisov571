namespace PassingTrips.Dtos;

public class FullTripDto
{
    public string Driver { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public int Price { get; set; }
    public int MaxCountPassenger { get; set; }
    public string Car { get; set; }
    public bool IsMusic { get; set; }
    public bool IsSmoking { get; set; }
    public bool IsAnimal { get; set; }
}