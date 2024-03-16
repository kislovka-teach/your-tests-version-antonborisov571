namespace PassingTrips.Models;

public class Review
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int RecipientId { get; set; }
    public User Recipient { get; set; }
    public string ReviewText { get; set; }
    public int Score { get; set; }
}