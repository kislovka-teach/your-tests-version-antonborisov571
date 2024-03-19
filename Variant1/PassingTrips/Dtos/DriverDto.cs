namespace PassingTrips.Dtos;

public class DriverDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Score { get; set; }
    public int CountTrips { get; set; }
    public List<ReviewDto> Reviews { get; set; }
    public int DrivingExperience { get; set; }
    public DateTime DateRegistration { get; set; }
    
}