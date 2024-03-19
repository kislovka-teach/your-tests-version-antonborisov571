namespace Freelance.Models;

public class Bid
{
    public int Id { get; set; }
    public int FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
}