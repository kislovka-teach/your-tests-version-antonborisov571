namespace Freelance.Dtos;

public class ReviewDto
{
    public string Text { get; set; }
    public decimal Rating { get; set; }
    public int FreelancerId { get; set; }
}