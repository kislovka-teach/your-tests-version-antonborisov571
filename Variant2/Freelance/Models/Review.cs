namespace Freelance.Models;

public class Review
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public string Text { get; set; }
    public decimal Rating { get; set; }
    public int FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
}