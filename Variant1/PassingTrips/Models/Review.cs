namespace PassingTrips.Models;

public class Review
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; set; }
    public string ReviewText { get; set; }
    public int Score { get; set; }
}