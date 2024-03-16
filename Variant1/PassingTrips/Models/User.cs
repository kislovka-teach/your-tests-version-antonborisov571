namespace PassingTrips.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateOnly DateRegistration { get; set; }
    public string NumberPhone { get; set; }
    public int DrivingExperience { get; set; }
    public List<Trip> DriverTrips { get; set; }
    public List<Trip> PassengerTrips { get; set; }
}