namespace PassingTrips.Dtos;

public class FindTripByCitiesDto
{
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime Date { get; set; }
}